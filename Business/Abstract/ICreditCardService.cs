using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        Task<IDataResult<CreditCard>>  Get(string id);

        Task<IDataResult<List<CreditCard>>>  GetAllByCustomerId(string customerId);

        Task<IResult> Add(CreditCard creditCard);

        Task<IResult> Delete(CreditCard creditCard);
    }
}