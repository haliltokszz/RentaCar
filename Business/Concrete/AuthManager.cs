using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthManager(ITokenHelper tokenHelper,
            IUserOperationClaimService userOperationClaimService, IUserService userService, IMapper mapper)
        {
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IResult> UserExists(string email)
        {
            var userResult = await _userService.GetByMail(email);
            if (!userResult.Success) return new ErrorResult(userResult.Message);
            if (userResult.Data != null) return new ErrorResult(CoreAspectMessages.UserAlreadyExists);

            return new SuccessResult();
        }

        [SecuredOperation("user")]
        public async Task<IResult> IsAuthenticated(string userMail, List<string> requiredRoles)
        {
            if (requiredRoles != null)
            {
                var user = (await _userService.GetByMail(userMail)).Data;
                var userClaims = _userService.GetClaims(user).Data;
                var doesUserHaveRequiredRoles =
                    requiredRoles.All(role => userClaims.Select(userClaim => userClaim.Name).Contains(role));
                if (!doesUserHaveRequiredRoles) return new ErrorResult(CoreAspectMessages.AuthorizationDenied);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claimsResult = _userService.GetClaims(user);
            if (!claimsResult.Success) return new ErrorDataResult<AccessToken>(claimsResult.Message);
            var accessToken = _tokenHelper.CreateToken(user, claimsResult.Data);

            return new SuccessDataResult<AccessToken>(accessToken, CoreAspectMessages.AccessTokenCreated);
        }

        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheckResult = await _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheckResult.Success) return new ErrorDataResult<User>(userToCheckResult.Message);

            var userToCheck = userToCheckResult.Data;
            if (userToCheck == null) return new ErrorDataResult<User>(CoreAspectMessages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                    userToCheck.PasswordSalt)) return new ErrorDataResult<User>(CoreAspectMessages.PasswordError);

            return new SuccessDataResult<User>(userToCheck, CoreAspectMessages.SuccessfulLogin);
        }

        public User CreatePasswordHash(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var newUser = _mapper.Map<User>(userForRegisterDto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _userService.Register(newUser);
            var user = (await _userService.GetByMail(newUser.Email)).Data;
            await _userOperationClaimService.AddUserClaim(user);
            return new SuccessDataResult<User>(user, CoreAspectMessages.UserRegistered);
        }
    }
}