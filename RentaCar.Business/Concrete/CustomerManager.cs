using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RentaCar.Business.Abstract;
using RentaCar.DataAccess.Abstract;
using RentaCar.DataAccess.Concrete;
using RentaCar.Entities.Abstract;
using RentaCar.Entities.Concrete;

namespace RentaCar.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private IUnitofWork _unitofWork;
        public CustomerManager(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
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
