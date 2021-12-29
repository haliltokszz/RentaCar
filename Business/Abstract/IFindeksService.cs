using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFindeksService
    {
        Task<IDataResult<Findeks>> Get(string id);

        Task<IDataResult<Findeks>> GetByCustomer(string customerId);

        Task<IDataResult<List<Findeks>>> GetAll();

        Task<IResult> Add(Findeks findeks);

        Task<IResult> Update(Findeks findeks);

        Task<IResult> Delete(Findeks findeks);

        IDataResult<Findeks> CalculateFindeksScore(Findeks findeks);
    }
}