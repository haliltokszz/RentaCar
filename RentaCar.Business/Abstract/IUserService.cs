using RentaCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.Business.Abstract
{
    public interface IUserService
    {
        Users Authenticate(string userName, string password);
    }
}
