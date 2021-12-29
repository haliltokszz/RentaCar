using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        Task<IDataResult<List<Rental>>> GetByCustomer(string customerId);
        Task<IDataResult<List<Rental>>> GetByCompany(string companyId);
        Task<IDataResult<List<Rental>>> GetByNoApprove();
        Task<IDataResult<List<Rental>>> GetByCar(string carId);

        Task<IDataResult<Rental>> Get(string id);

        Task<IDataResult<List<Rental>>> GetAll();

        Task<IResult> Add(Rental rental);

        Task<IResult> Update(Rental rental);

        Task<IResult> Delete(Rental rental);
    }
}