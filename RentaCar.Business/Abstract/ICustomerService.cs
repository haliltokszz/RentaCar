using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customers> GetAll();
        void Add(Customers customer);
        void Update(Customers customer);
        void Delete(Customers customer);
    }
}
