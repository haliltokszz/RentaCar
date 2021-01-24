using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RentaCar.Business.Abstract;
using RentaCar.DataAccess.Concrete;
using RentaCar.Entities.Concrete;

namespace RentaCar.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private UnitofWork _unitofWork;
        public CustomerManager()
        {
            _unitofWork = new UnitofWork();
        }
        public void Add(Customers customer)
        {
            _unitofWork.Customers.Add(customer);
        }

        public void Delete(Customers customer)
        {
            _unitofWork.Customers.Delete(customer);
        }

        public List<Customers> GetAll()
        {
            return _unitofWork.Customers.GetList();
        }

        public void Update(Customers customer)
        {
            _unitofWork.Customers.Update(customer);
        }
    }
}
