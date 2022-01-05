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
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public async Task<IDataResult<OperationClaim>> Get(string id)
        {
            return new SuccessDataResult<OperationClaim>(await _operationClaimDal.GetAsync(o => o.Id == id));
        }

        public async Task<IDataResult<OperationClaim>> GetByName(string name)
        {
            return new SuccessDataResult<OperationClaim>(await _operationClaimDal.GetAsync(o => o.Name == name));
        }

        public async Task<IDataResult<List<OperationClaim>>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(await _operationClaimDal.GetAllAsync());
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(OperationClaim operationClaim)
        {
            await _operationClaimDal.AddAsync(operationClaim);

            return new SuccessResult(Messages.OperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Update(OperationClaim operationClaim)
        {
            await _operationClaimDal.UpdateAsync(operationClaim);

            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Delete(OperationClaim operationClaim)
        {
            await _operationClaimDal.DeleteAsync(operationClaim);

            return new SuccessResult(Messages.OperationClaimDeleted);
        }
    }
}