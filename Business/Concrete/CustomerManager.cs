using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private UnitofWork _unitofWork;
        public CustomerManager()
        {
            _unitofWork = new UnitofWork();
        }
        public void Add(Customer customer)
        {
            _unitofWork.Customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _unitofWork.Customers.Delete(customer);
        }

        public List<Customer> GetAll()
        {
            return _unitofWork.Customers.GetList();
        }

        public void Update(Customer customer)
        {
            _unitofWork.Customers.Update(customer);
        }
    }
}
