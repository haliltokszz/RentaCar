using RentaCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Entities.Concrete
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
