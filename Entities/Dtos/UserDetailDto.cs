using System;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class UserDetailDto : IDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public short Age { get; set; }
    }
}