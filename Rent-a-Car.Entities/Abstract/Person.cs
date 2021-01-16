using Rent_a_Car.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent_a_Car.Entities.Abstract
{
    public abstract class Person:IEntity
    {
        public int Id { get; set; }
        public string TCno { get; set; }
        public string NameSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
