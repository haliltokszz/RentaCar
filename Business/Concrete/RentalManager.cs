using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FulentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarDal _carDal;
        private readonly IFindeksDal _findeksDal;
        private readonly ICustomerDal _customerDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal, IFindeksDal findeksDal, ICustomerDal customerDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
            _findeksDal = findeksDal;
            _customerDal = customerDal;
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

        [SecuredOperation("user,rental.get,moderator,admin")]
        public async Task<IDataResult<List<Rental>>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(await _rentalDal.GetAllAsync());
        }

        [SecuredOperation("user,rental.get,moderator,admin")]
        public async Task<IDataResult<Rental>> Get(string id)
        {
            return new SuccessDataResult<Rental>(await _rentalDal.GetAsync(r => r.Id == id));
        }

        public async Task<IDataResult<List<Rental>>> GetByCar(string carId)
        {
            return new SuccessDataResult<List<Rental>>(await _rentalDal.GetAllAsync(r => r.CarId == carId, r => r.Car,
                r => r.Company, r => r.Customer));
        }

        public async Task<IDataResult<List<Rental>>> GetByCompany(string companyId)
        {
            return new SuccessDataResult<List<Rental>>(await _rentalDal.GetAllAsync(r => r.CompanyId == companyId));
        }

        public async Task<IDataResult<List<Rental>>> GetByCustomer(string customerId)
        {
            return new SuccessDataResult<List<Rental>>(await _rentalDal.GetAllAsync(r => r.CustomerId == customerId));
        }

        public async Task<IDataResult<List<Rental>>> GetByNoApprove()
        {
            return new SuccessDataResult<List<Rental>>(await _rentalDal.GetAllAsync(r => !r.Approve));
        }

        private async Task<IResult> IsRentable(Rental rental)
        {
            var rentals = await _rentalDal.GetAllAsync(r => r.CarId == rental.CarId);

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