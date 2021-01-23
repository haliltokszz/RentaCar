using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employees> GetAll();
        List<Employees> GetByCompany(int employeeId);
        void Add(Employees employee);
        void Update(Employees employee);
        void Delete(Employees employee);
    }
}
