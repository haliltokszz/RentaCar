using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        Task<IDataResult<UserOperationClaim>> GetById(string id);

        Task<IDataResult<List<UserOperationClaim>>> GetAll();

        Task<IResult> AddUserClaim(User user);

        Task<IResult> Add(UserOperationClaim userOperationClaim);

        Task<IResult> Update(UserOperationClaim userOperationClaim);

        Task<IResult> Delete(UserOperationClaim userOperationClaim);
    }
}