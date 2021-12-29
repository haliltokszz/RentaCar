using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        User CreatePasswordHash(User user, string password);
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password);
        Task<IResult> UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        Task<IResult> IsAuthenticated(string userMail, List<string> requiredRoles);
    }
}
