using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public async Task<IResult> Add(Company company)
        {
            await _companyDal.AddAsync(company);
            return new SuccessResult(Messages.CompanyAdded);
        }

        public async Task<IResult> Delete(Company company)
        {
            await _companyDal.DeleteAsync(company);
            return new SuccessResult(Messages.CompanyDeleted);
        }

        public async Task<IDataResult<List<Company>>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(await _companyDal.GetAllAsync());
        }

        public async Task<IResult> Update(Company company)
        {
            await _companyDal.UpdateAsync(company);
            return new SuccessResult(Messages.CompanyUpdated);
        }
    }
}