using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Entities.Abstract
{
    public interface IUser
    {
        int UserId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
