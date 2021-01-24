using RentaCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RentaCar.Core.Entities;

namespace RentaCar.Entities.Concrete
{
    [Table("Customers")]
    public partial class Customers : Users, IEntity
    {
    }
}
