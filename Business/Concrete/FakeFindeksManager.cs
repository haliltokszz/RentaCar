using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FakeFindeksManager : IFindeksService
    {
        private readonly IFindeksDal _findeksDal;

        public FakeFindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        [SecuredOperation("findeks.get,moderator,admin")]
        public async Task<IDataResult<Findeks>> Get(string id)
        {
            return new SuccessDataResult<Findeks>(await _findeksDal.GetAsync(f => f.Id == id));
        }

        [SecuredOperation("user")]
        public async Task<IDataResult<Findeks>> GetByCustomer(string customerId)
        {
            var findeks = await _findeksDal.GetAsync(f => f.CustomerId == customerId);
            if (findeks == null) return new ErrorDataResult<Findeks>(Messages.FindeksNotFound);

            return new SuccessDataResult<Findeks>(findeks);
        }

        [SecuredOperation("findeks.get,moderator,admin")]
        public async Task<IDataResult<List<Findeks>>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(await _findeksDal.GetAllAsync());
        }

        [SecuredOperation("user")]
        public async Task<IResult> Add(Findeks findeks)
        {
            var newFindeks = CalculateFindeksScore(findeks).Data;
            await _findeksDal.AddAsync(newFindeks);

            return new SuccessResult(Messages.FindeksAdded);
        }

        [SecuredOperation("findeks.update,moderator,admin")]
        public async Task<IResult> Update(Findeks findeks)
        {
            var newFindeks = CalculateFindeksScore(findeks).Data;
            await _findeksDal.UpdateAsync(newFindeks);

            return new SuccessResult(Messages.FindeksUpdated);
        }

        [SecuredOperation("findeks.delete,moderator,admin")]
        public async Task<IResult> Delete(Findeks findeks)
        {
            await _findeksDal.DeleteAsync(findeks);

            return new SuccessResult(Messages.FindeksDeleted);
        }

        public IDataResult<Findeks> CalculateFindeksScore(Findeks findeks) // Fake
        {
            findeks.Score = (short)new Random().Next(0, 1901);

            return new SuccessDataResult<Findeks>(findeks);
        }
    }
}