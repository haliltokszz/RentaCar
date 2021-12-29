using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IDataResult<OperationClaim>> GetById(string id);

        Task<IDataResult<OperationClaim>> GetByName(string name);

        Task<IDataResult<List<OperationClaim>>> GetAll();

        Task<IResult> Add(OperationClaim operationClaim);

        Task<IResult> Update(OperationClaim operationClaim);

        Task<IResult> Delete(OperationClaim operationClaim);
    }
}