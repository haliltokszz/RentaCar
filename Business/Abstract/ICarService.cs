﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        Task<IDataResult<List<Car>>> GetAll();
        Task<IDataResult<List<Car>>> GetByCompany(string companyId);
        Task<IDataResult<List<Car>>> GetByAvailable();
        Task<IDataResult<Car>> Get(string carId);
        Task<IResult> Add(Car car);
        Task<IResult> Update(Car car);
        Task<IResult> Delete(Car car);
    }
}
