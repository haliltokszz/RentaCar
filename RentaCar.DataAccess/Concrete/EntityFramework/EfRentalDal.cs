using RentaCar.Core.DataAccess.EntityFramework;
using RentaCar.DataAccess.Abstract;
using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rentals, RentaCarContext>, IRentalDal
    {
    }
}
