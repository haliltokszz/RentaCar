using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Filters;

namespace Business.Abstract
{
    public interface ICarService
    {
        Task<IDataResult<List<Car>>> GetAll();
        Task<IDataResult<List<Car>>> GetAllWithFilter(PageFilter pageFilter, CarFilter filter);
        Task<IDataResult<List<Car>>> GetByAvailable();
        Task<IDataResult<Car>> Get(string carId);
        Task<IResult> Add(Car car);
        Task<IResult> Update(Car car);
        Task<IResult> Delete(Car car);
    }
}