using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Entities.Concrete
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<Car> Cars { get; set; }
        public int Score { get; set; }

    }
}
