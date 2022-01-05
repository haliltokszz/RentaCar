using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Filters;

namespace Business.Abstract
{
    public interface IBrandService
    {
        Task<IDataResult<Brand>> Get(string id);

        Task<IDataResult<List<Brand>>> GetAll(BrandAndColorFilter filter= null);

        Task<IResult> Add(Brand brand);

        Task<IResult> Update(Brand brand);

        Task<IResult> Delete(Brand brand);
    }
}