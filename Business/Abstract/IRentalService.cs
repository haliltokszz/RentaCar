using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Filters;

namespace Business.Abstract
{
    public interface IRentalService
    {
        Task<IDataResult<List<Rental>>> GetByNoApprove();
        Task<IDataResult<Rental>> Get(string id);
        Task<IDataResult<List<Rental>>> GetAll(PageFilter pageFilter, RentalFilter filter = null);
        Task<IResult> Add(Rental rental);
        Task<IResult> Delivered(Rental rental);
        Task<IResult> Approve(Rental rental);
        Task<IResult> Update(Rental rental);
        Task<IResult> Delete(Rental rental);
    }
}