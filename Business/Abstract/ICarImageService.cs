using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        Task<IDataResult<CarImage>> Get(string id);

        Task<IDataResult<List<CarImage>>> GetAll();

        Task<IDataResult<List<CarImage>>> GetImagesByCar(string carId);

        Task<IResult> Add(CarImage carImage, IFormFile file);

        Task<IResult> Update(CarImage carImage, IFormFile file);

        Task<IResult> Delete(CarImage carImage);
    }
}