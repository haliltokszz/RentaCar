using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Business.Abstract
{
    public interface ICarService
    {
        List<Cars> GetAll();
        void Add(Cars car);
        void Update(Cars car);
        void Delete(Cars car);
    }
}
