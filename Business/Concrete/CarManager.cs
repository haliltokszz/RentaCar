﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FulentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task<IDataResult<List<Car>>> GetByAvailable()
        {
            return new SuccessDataResult<List<Car>>(await _carDal.GetAllAsync(c => c.Available));
        }

        [CacheAspect]
        public async Task<IDataResult<Car>> Get(string id)
        {
            return new SuccessDataResult<Car>(await _carDal.GetAsync(c => c.Id == id));
        }

        [CacheAspect]
        public async Task<IDataResult<List<Car>>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(await _carDal.GetAllAsync());
        }

        public async Task<IDataResult<List<Car>>> GetByCompany(string companyId)
        {
            return new SuccessDataResult<List<Car>>(await _carDal.GetAllAsync(car => car.CompanyId == companyId,
                c => c.Company, c => c.CarImage, c => c.Brand, c => c.Color));
        }


        [SecuredOperation("car.add,moderator,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public async Task<IResult> Add(Car car)
        {
            await _carDal.AddAsync(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.update,moderator,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public async Task<IResult> Update(Car car)
        {
            await _carDal.UpdateAsync(car);

            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("car.delete,moderator,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public async Task<IResult> Delete(Car car)
        {
            await _carDal.DeleteAsync(car);

            return new SuccessResult(Messages.CarDeleted);
        }
    }
}