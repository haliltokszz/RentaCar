using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Filter;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Filters;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public async Task<IDataResult<Brand>> Get(string id)
        {
            return new SuccessDataResult<Brand>(await _brandDal.GetAsync(b => b.Id == id));
        }

        public async Task<IDataResult<List<Brand>>> GetAll(BrandAndColorFilter filter = null)
        {
            if(filter == null || filter.Name==null) return new SuccessDataResult<List<Brand>>(await _brandDal.GetAllAsync());
            
            var exp = Filter.DynamicFilter<Brand, BrandAndColorFilter>(filter);
            return new SuccessDataResult<List<Brand>>(await _brandDal.GetAllAsync(exp));
        }

        [SecuredOperation("brand.add,moderator,admin")]
        public async Task<IResult> Add(Brand brand)
        {
            await _brandDal.AddAsync(brand);
            return new SuccessResult(Messages.BrandCreated);
        }

        [SecuredOperation("brand.update,moderator,admin")]
        public async Task<IResult> Update(Brand brand)
        {
            await _brandDal.UpdateAsync(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        [SecuredOperation("brand.delete,moderator,admin")]
        public async Task<IResult> Delete(Brand brand)
        {
            await _brandDal.DeleteAsync(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
    }
}