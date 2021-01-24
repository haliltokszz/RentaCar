using RentaCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RentaCar.Core.Entities;

namespace RentaCar.Entities.Concrete
{
    [Table("Employees")]
    public partial class Employees : Users, IEntity
    {
        [ForeignKey("Companies")]
        public int CompanyId { get; set; }
        public Companies Company { get; set; }
    }
}
