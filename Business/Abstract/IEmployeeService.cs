using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeService 
    {
        List<Employee> GetAll();
        List<Employee> GetByCompany(int companyId);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
