using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerManager)
        {
            _customerDal = customerManager;
        }

        [SecuredOperation("customer.get,moderator,admin")]
        public async Task<IDataResult<Customer>> Get(string id)
        {
            return new SuccessDataResult<Customer>(await _customerDal.GetAsync(c => c.Id == id, c => c.Company,
                c => c.User));
        }

        [SecuredOperation("customer.get,moderator,admin")]
        public async Task<IDataResult<Customer>> GetCustomerByUser(string userId)
        {
            return new SuccessDataResult<Customer>(await _customerDal.GetAsync(c => c.UserId == userId, c => c.User,
                c => c.Company));
        }

        [SecuredOperation("customer.get,moderator,admin")]
        public async Task<IDataResult<List<Customer>>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(await _customerDal.GetAllAsync());
        }

        public async Task<IResult> Add(Customer customer)
        {
            await _customerDal.AddAsync(customer);

            return new SuccessResult(Messages.CustomerCreated);
        }

        [SecuredOperation("customer.update,moderator,admin")]
        public async Task<IResult> Update(Customer customer)
        {
            await _customerDal.UpdateAsync(customer);

            return new SuccessResult(Messages.CustomerUpdated);
        }

        [SecuredOperation("customer.delete,moderator,admin")]
        public async Task<IResult> Delete(Customer customer)
        {
            await _customerDal.DeleteAsync(customer);

            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}