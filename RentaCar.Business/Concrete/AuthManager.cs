using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RentaCar.Business.Abstract;
using RentaCar.Core.Utilities.Security.Hashing;
using RentaCar.DataAccess.Concrete;
using RentaCar.Entities.Abstract;
using RentaCar.Entities.Dtos;

namespace RentaCar.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private UnitofWork _unitofWork = new UnitofWork();
        private readonly string _key;

        public AuthManager(string key)
        {
            _key = key;
        }

        public string CreateAccessToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string Login(UserForLoginDto userForLoginDto, string userType)
        {
            Users userToCheck;
            if (userType == "Customer")
                 userToCheck = _unitofWork.Customers.Get(u=> userForLoginDto.UserName == u.UserName);
            else
                userToCheck = _unitofWork.Employees.Get(u => userForLoginDto.UserName == u.UserName);
            if (userToCheck == null)
            {
                return "User is not exist";
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return "User password is not correct";
            }

            return CreateAccessToken(userToCheck);

        }

        public Users CreatePasswordHash(Users user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
        }

        public bool UserExist(string userName, string userType)
        {
            if(userType=="Customer")
                if (_unitofWork.Customers.Get(u => u.UserName == userName) != null) return true;
                else return false;
            else if (userType=="Employee")
                if (_unitofWork.Employees.Get(u => u.UserName == userName) != null) return true;
                else return false;

            return false;
        }
    }
}
