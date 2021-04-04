using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class EmployeeManager: IEmployeeService
    {
        private UnitofWork _unitofWork;

        public EmployeeManager()
        {
            _unitofWork = new UnitofWork();
        }
        public List<Employee> GetAll()
        {
            return _unitofWork.Employees.GetList();
        }

        public List<Employee> GetByCompany(int companyId)
        {
            return _unitofWork.Employees.GetList(filter: employees => employees.CompanyId == companyId);
        }

        public void Add(Employee employee)
        {
            _unitofWork.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            _unitofWork.Employees.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _unitofWork.Employees.Delete(employee);
        }
    }
}
