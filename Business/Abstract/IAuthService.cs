using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        string Login(UserForLoginDto userForLoginDto, string userType);
        User CreatePasswordHash(User user, string password);
        bool UserExist(string userName, string userType);
    }
}
