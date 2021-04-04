using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private UnitofWork _unitofWork;

        public CompanyManager()
        {
            _unitofWork = new UnitofWork();
        }
        public void Add(Company company)
        {
            _unitofWork.Companies.Add(company);
        }

        public void Delete(Company company)
        {
            _unitofWork.Companies.Delete(company);
        }

        public List<Company> GetAll()
        {
            return _unitofWork.Companies.GetList();
        }

        public void Update(Company company)
        {
            _unitofWork.Companies.Update(company);
        }
    }
}
