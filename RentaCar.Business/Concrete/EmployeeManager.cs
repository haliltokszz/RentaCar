using System;
using System.Collections.Generic;
using System.Text;
using RentaCar.Business.Abstract;
using RentaCar.DataAccess.Concrete;
using RentaCar.Entities.Concrete;

namespace RentaCar.Business.Concrete
{
    public class EmployeeManager: IEmployeeService
    {
        private UnitofWork _unitofWork;

        public EmployeeManager()
        {
            _unitofWork = new UnitofWork();
        }
        public List<Employees> GetAll()
        {
            return _unitofWork.Employees.GetList();
        }

        public List<Employees> GetByCompany(int companyId)
        {
            return _unitofWork.Employees.GetList(filter: employees => employees.CompanyId == companyId);
        }

        public void Add(Employees employee)
        {
            _unitofWork.Employees.Add(employee);
        }

        public void Update(Employees employee)
        {
            _unitofWork.Employees.Update(employee);
        }

        public void Delete(Employees employee)
        {
            _unitofWork.Employees.Delete(employee);
        }
    }
}
