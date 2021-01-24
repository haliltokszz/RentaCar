using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RentaCar.Core.Entities;
using RentaCar.Entities.Concrete;

namespace RentaCar.Entities.Abstract
{
    [Table("Users")]
    public abstract class Users : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string TCno { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        //public string Discriminator { get; set; }
    }
}
