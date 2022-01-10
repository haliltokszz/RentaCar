using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<Customer>> Get(string id);
        Task<IDataResult<Customer>> GetCustomerByUser(string userId);

        Task<IDataResult<List<Customer>>> GetAll();

        Task<IResult> Add(Customer customer);

        Task<IResult> Update(Customer customer);

        Task<IResult> Delete(Customer customer);
    }
}