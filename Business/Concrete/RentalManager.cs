using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FulentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Filters;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly ICarDal _carDal;
        private readonly ICustomerDal _customerDal;
        private readonly IFindeksDal _findeksDal;
        private readonly IRentalDal _rentalDal;
        private readonly IRentalCountDal _rentalCountDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal, IFindeksDal findeksDal, ICustomerDal customerDal,
            IRentalCountDal rentalCountDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
            _findeksDal = findeksDal;
            _customerDal = customerDal;
            _rentalCountDal = rentalCountDal;
        }

        [SecuredOperation("user,rental.add,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public async Task<IResult> Add(Rental rental)
        {
            var result = BusinessRules.Run(await IsRentable(rental),
                await DriveExperienceSufficiency(rental),
                await CheckFindeksScoreSufficiency(rental));
            if (result != null) return result;

            var car = await _carDal.GetAsync(c => c.Id == rental.CarId);
            car.Available = false;
            await _carDal.UpdateAsync(car);
            await _rentalDal.AddAsync(rental);

            return new SuccessResult(Messages.RentalCreated);
        }

        public async Task<IResult> Delivered(Rental rental)
        {
            rental.Delivered = true;
            rental.DeliveredDate = DateTime.UtcNow;
            var car = await _carDal.GetAsync(c => c.Id == rental.CarId);
            car.Available = true;
            car.KmCurrent = rental.KmDelivery;
            await _carDal.UpdateAsync(car);
            await _rentalDal.UpdateAsync(rental);

            return new SuccessResult(Messages.RentalDelivered);
        }

        public async Task<IResult> Approve(Rental rental)
        {
            rental.Approve = true;
            rental.ApprovalDate = DateTime.UtcNow;
            var car = await _carDal.GetAsync(c => c.Id == rental.CarId);
            car.Available = false;
            await _carDal.UpdateAsync(car);
            await _rentalDal.UpdateAsync(rental);

            return new SuccessResult(Messages.RentalApproved);
        }

        [SecuredOperation("rental.update,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public async Task<IResult> Update(Rental customer)
        {
            await _rentalDal.UpdateAsync(customer);

            return new SuccessResult(Messages.RentalUpdated);
        }

        [SecuredOperation("rental.delete,moderator,admin")]
        public async Task<IResult> Delete(Rental customer)
        {
            await _rentalDal.DeleteAsync(customer);

            return new SuccessResult(Messages.RentalDeleted);
        }

        private async Task<IResult> AddRentalCountByCategory(CarCategories category)
        {
            RentalCount rentalCountByCategory =
                await _rentalCountDal.GetAsync(r => r.Category == category && r.Month == DateTime.Now.Month);
            if (rentalCountByCategory == null)
            {
                var newRentalCountPerMonthByCategory = new RentalCount
                {
                    Category = category,
                    Month = DateTime.Now.Month,
                    TotalRent = 1
                };
                await _rentalCountDal.AddAsync(newRentalCountPerMonthByCategory);
                return new SuccessResult();
            }

            rentalCountByCategory.TotalRent++;
            await _rentalCountDal.UpdateAsync(rentalCountByCategory);
            return new SuccessResult();
        }

        [SecuredOperation("user,rental.get,moderator,admin")]
        public async Task<IDataResult<List<Rental>>> GetAll(PageFilter pageFilter, RentalFilter filter = null)
        {
            return new SuccessPagedDataResult<List<Rental>>(
                await _rentalDal.GetAllAsync(pageFilter, filter, r => r.Company, r => r.Customer, r => r.Car));
        }

        [SecuredOperation("user,rental.get,moderator,admin")]
        public async Task<IDataResult<Rental>> Get(string id)
        {
            return new SuccessDataResult<Rental>(await _rentalDal.GetAsync(r => r.Id == id));
        }


        public async Task<IDataResult<List<Rental>>> GetByNoApprove()
        {
            return new SuccessDataResult<List<Rental>>(await _rentalDal.GetAllAsync(r => !r.Approve));
        }

        private async Task<IResult> IsRentable(Rental rental)
        {
            var rentals = await _rentalDal.GetAllAsync(r => r.CarId == rental.CarId, r => r.Car);

            if (rentals.Any(r =>
                    !r.Delivered || r.EndDate > DateTime.UtcNow
                )) return new ErrorResult(Messages.RentalNotAvailable);

            return new SuccessResult();
        }

        private async Task<IResult> CheckFindeksScoreSufficiency(Rental rental)
        {
            var car = await _carDal.GetAsync(c => c.Id == rental.CarId);
            var findeks = await _findeksDal.GetAsync(f => f.CustomerId == rental.CustomerId);

            if (findeks == null) return new ErrorResult(Messages.FindeksNotFound);
            if (findeks.Score < car.MinFindeksScore) return new ErrorResult(Messages.FindeksNotEnoughForCar);

            return new SuccessResult();
        }

        private async Task<IResult> DriveExperienceSufficiency(Rental rental)
        {
            var customer = await _customerDal.GetAsync(c => c.Id == rental.CustomerId, c => c.User);
            var car = await _carDal.GetAsync(c => c.Id == rental.CarId);

            if (car.RequiredDriveExperience != customer.DriveExperience)
                return new ErrorResult(Messages.DriveExperienceInsufficient);
            if (car.LimitMinAge > customer.User.Age) return new ErrorResult(Messages.CustomerAgeInsufficient);

            return new SuccessResult();
        }
    }
}