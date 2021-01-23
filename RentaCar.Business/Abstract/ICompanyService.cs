using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Business.Abstract
{
    public interface ICompanyService
    {
        List<Companies> GetAll();
        List<Cars> GetCars();
        void Add(Companies company);
        void Update(Companies company);
        void Delete(Companies company);
    }
}
