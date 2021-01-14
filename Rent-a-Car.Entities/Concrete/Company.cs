using System;
using System.Collections.Generic;
using System.Text;

namespace Rent_a_Car.Entities.Concrete
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int TotalCar { get; set; }
        public int Score { get; set; }
    }
}
