﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IOperationClaimDal _operationClaimDal;

        public UserManager(IUserDal userDal, IMapper mapper, IUserOperationClaimDal userOperationClaimDal,
            IOperationClaimDal operationClaimDal)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userOperationClaimDal = userOperationClaimDal;
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("user,user.get,moderator,admin")]
        public async Task<IDataResult<UserDetailDto>> Get(string id)
        {
            var userDto = _mapper.Map<UserDetailDto>(await _userDal.GetAsync(u => u.Id == id));
            return new SuccessDataResult<UserDetailDto>(userDto);
        }
        
        [SecuredOperation("user,user.get,moderator,admin")]
        public async Task<IDataResult<UserDetailDto>> GetUserDetailByMail(string mail)
        {
            var userDto = _mapper.Map<UserDetailDto>(await _userDal.GetAsync(u => u.Email == mail));
            return new SuccessDataResult<UserDetailDto>(userDto);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public async Task<IDataResult<User>> GetByMail(string email)
        {
            return new SuccessDataResult<User>(await _userDal.GetAsync(u => u.Email == email));
        }

        [SecuredOperation("user,user.get,moderator,admin")]
        public async Task<IDataResult<List<UserDetailDto>>> GetAll()
        {
            var userDto = _mapper.Map<List<UserDetailDto>>(await _userDal.GetAllAsync());
            return new SuccessDataResult<List<UserDetailDto>>(userDto);
        }

        public async Task<IResult> Add(UserDetailDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.UserCreated);
        }

        public async Task<IResult> Register(User user)
        {
            await _userDal.AddAsync(user);
            var defaultOperationClaim = await _operationClaimDal.GetAsync(o => o.Name == "user");
            if (defaultOperationClaim is null)
            {
                defaultOperationClaim = new OperationClaim
                {
                    Name = "user"
                };
                await _operationClaimDal.AddAsync(defaultOperationClaim);
            }

            await _userOperationClaimDal.AddAsync(new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = defaultOperationClaim.Id
            });
            return new SuccessResult(Messages.UserCreated);
        }

        [SecuredOperation("user.update,moderator,admin")]
        public async Task<IResult> Update(UserDetailDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userDal.UpdateAsync(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        [SecuredOperation("user.delete,moderator,admin")]
        public async Task<IResult> Delete(UserDetailDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userDal.DeleteAsync(user);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}