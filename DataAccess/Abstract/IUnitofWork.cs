using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitofWork : IDisposable
    {
        IUserDal Users { get; }
        ICarDal Cars { get; }
        ICompanyDal Companies { get; }
        ICustomerDal Customers { get;}
        IRentalDal Rentals { get; }
        IBrandDal Brands { get; }
        ICarImageDal CarImages { get; }
        IColorDal Colors { get; }
        IFindeksDal Findekses { get; }
        IOperationClaimDal OperationClaims { get; }
        IUserOperationClaimDal UserOperationClaims { get; }
        Task<bool> Save();
    }
}
