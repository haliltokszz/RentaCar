using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDetailDto>> Get(string id);
        Task<IDataResult<List<UserDetailDto>>> GetAll();
        Task<IResult> Add(UserDetailDto user);
        Task<IResult> Register(User user);
        Task<IResult> Update(UserDetailDto user);
        Task<IResult> Delete(UserDetailDto user);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        Task<IDataResult<User>> GetByMail(string userMail);
        Task<IDataResult<UserDetailDto>> GetUserDetailByMail(string userMail);
    }
}