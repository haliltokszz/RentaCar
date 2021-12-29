using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        Task<IDataResult<List<Company>>> GetAll();
        Task<IResult> Add(Company company);
        Task<IResult> Update(Company company);
        Task<IResult> Delete(Company company);
    }
}
