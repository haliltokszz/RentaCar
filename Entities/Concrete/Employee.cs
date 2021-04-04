using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    [Table("Employees")]
    public partial class Employee : User
    {
        [ForeignKey("Companies")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
