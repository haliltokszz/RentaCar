using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        Task<IDataResult<Color>> Get(string id);

        Task<IDataResult<List<Color>>> GetAll();

        Task<IResult> Add(Color color);

        Task<IResult> Update(Color color);

        Task<IResult> Delete(Color color);
    }
}