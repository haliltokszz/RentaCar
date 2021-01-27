using System;
using System.Collections.Generic;
using System.Text;
using RentaCar.Core.Entities;

namespace RentaCar.Entities.Dtos
{
    public class UserForLoginDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
