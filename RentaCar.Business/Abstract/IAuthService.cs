using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RentaCar.Entities.Abstract;
using RentaCar.Entities.Dtos;

namespace RentaCar.Business.Abstract
{
    public interface IAuthService
    {
        string Login(UserForLoginDto userForLoginDto, string userType);
        Users CreatePasswordHash(Users user, string password);
        bool UserExist(string userName, string userType);
    }
}
