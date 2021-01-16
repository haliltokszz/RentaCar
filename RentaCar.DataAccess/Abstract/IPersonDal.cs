using RentaCar.Core.DataAccess;
using RentaCar.Entities.Abstract;
using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.DataAccess.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
    }
}
