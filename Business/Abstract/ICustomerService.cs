using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<Customer>> Get(string id);

        Task<IDataResult<List<Customer>>> GetAll();

        Task<IResult> Add(Customer customer);

        Task<IResult> Update(Customer customer);

        Task<IResult> Delete(Customer customer);
    }
}
