using Rent_a_Car.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent_a_Car.Entities.Concrete
{
    public class Employee : Person, IUser
    {
        public int EmployeeId{ get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int UserId { get ; set; }
        public string UserName { get; set ; }
        public string Password { get; set ; }
        
    }
}
