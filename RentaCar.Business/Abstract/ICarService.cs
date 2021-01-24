using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Business.Abstract
{
    public interface ICarService
    {
        List<Cars> GetAll();
        List<Cars> GetByCompany(int companyId);
        List<Cars> GetByAvailable();
        void Add(Cars car);
        void Update(Cars car);
        void Delete(Cars car);
    }
}
