using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IOperationClaimService operationClaimService,
            IUserOperationClaimDal userOperationClaimDal
        )
        {
            _operationClaimService = operationClaimService;
            _userOperationClaimDal = userOperationClaimDal;
        }

        [SecuredOperation("admin")]
        public async Task<IDataResult<UserOperationClaim>> Get(string id)
        {
            return new SuccessDataResult<UserOperationClaim>(await _userOperationClaimDal.GetAsync(u => u.Id == id));
        }

        [SecuredOperation("admin")]
        public async Task<IDataResult<List<UserOperationClaim>>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(await _userOperationClaimDal.GetAllAsync());
        }

        public async Task<IResult> AddUserClaim(User user)
        {
            var operationClaim =(await _operationClaimService.GetByName("user")).Data;
            var userOperationClaim = new UserOperationClaim {OperationClaimId = operationClaim.Id, UserId = user.Id};
            await _userOperationClaimDal.AddAsync(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.AddAsync(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Update(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.UpdateAsync(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Delete(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.DeleteAsync(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }
    }
}