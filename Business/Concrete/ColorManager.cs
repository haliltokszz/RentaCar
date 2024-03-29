﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Filter;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Filters;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public async Task<IDataResult<Color>> Get(string id)
        {
            return new SuccessDataResult<Color>(await _colorDal.GetAsync(c => c.Id == id));
        }
        public async Task<IDataResult<List<Color>>> GetAll(BrandAndColorFilter filter = null)
        {
            if(filter==null) return new SuccessDataResult<List<Color>>(await _colorDal.GetAllAsync());
            
            var exp = Filter.DynamicFilter<Color, BrandAndColorFilter>(filter);
            return new SuccessDataResult<List<Color>>(await _colorDal.GetAllAsync(exp));
        }

        [SecuredOperation("color.add,moderator,admin")]
        public async Task<IResult> Add(Color color)
        {
            await _colorDal.AddAsync(color);

            return new SuccessResult(Messages.ColorCreated);
        }

        [SecuredOperation("color.update,moderator,admin")]
        public async Task<IResult> Update(Color color)
        {
            await _colorDal.UpdateAsync(color);

            return new SuccessResult(Messages.ColorUpdated);
        }

        [SecuredOperation("color.delete,moderator,admin")]
        public async Task<IResult> Delete(Color color)
        {
            await _colorDal.DeleteAsync(color);

            return new SuccessResult(Messages.ColorDeleted);
        }
    }
}