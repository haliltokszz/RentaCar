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
    public class Employees : Users, IEntity
    {
        public int EmployeeId{ get; set; }
        [ForeignKey("Companies")]
        public int CompanyId { get; set; }
        public Companies Company { get; set; }

    }
}
