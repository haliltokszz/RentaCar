using System;
using System.Collections.Generic;
using System.Text;
using RentaCar.Business.Abstract;
using RentaCar.DataAccess.Concrete;
using RentaCar.Entities.Concrete;

namespace RentaCar.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private UnitofWork _unitofWork;

        public CompanyManager()
        {
            _unitofWork = new UnitofWork();
        }
        public void Add(Companies company)
        {
            _unitofWork.Companies.Add(company);
        }

        public void Delete(Companies company)
        {
            _unitofWork.Companies.Delete(company);
        }

        public List<Companies> GetAll()
        {
            return _unitofWork.Companies.GetList();
        }

        public void Update(Companies company)
        {
            _unitofWork.Companies.Update(company);
        }
    }
}
