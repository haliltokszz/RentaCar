using RentaCar.Core.DataAccess.EntityFramework;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Abstract;
using RentaCar.DataAccess.Concrete.EntityFramework;
using RentaCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rent_a_Car.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<Users, RentaCarContext>, IUserDal
    {
    }
}
