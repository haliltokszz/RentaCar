using System;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TCno { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}