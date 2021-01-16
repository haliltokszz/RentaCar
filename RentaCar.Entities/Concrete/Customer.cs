using RentaCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Entities.Concrete
{
    public class Customer : Person
    {
        public int CustomerId{ get; set; }
    }
}
