using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.DataAccess.Abstract
{
    public interface IUnitofWork : IDisposable
    {
        IUserDal Users { get; }
        ICarDal Cars { get; }
        ICompanyDal Companies { get; }
        ICustomerDal Customers { get;}
        IRentalDal Rentals { get; }
        IEmployeeDal Employees { get; }
        int Save();
    }
}
