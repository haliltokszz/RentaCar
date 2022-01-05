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
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [SecuredOperation("user")]
        public async Task<IDataResult<CreditCard>> Get(string id)
        {
            return new SuccessDataResult<CreditCard>(await _creditCardDal.GetAsync(c => c.Id == id));
        }

        [SecuredOperation("user")]
        public async Task<IDataResult<List<CreditCard>>> GetAllByCustomerId(string customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(await _creditCardDal.GetAllAsync(c => c.CustomerId == customerId));
        }

        [SecuredOperation("user")]
        public async Task<IResult> Add(CreditCard creditCard)
        {
            await _creditCardDal.AddAsync(creditCard);

            return new SuccessResult(Messages.CreditCardAdded);
        }

        [SecuredOperation("user")]
        public async Task<IResult> Delete(CreditCard creditCard)
        {
            await _creditCardDal.DeleteAsync(creditCard);

            return new SuccessResult(Messages.CreditCardDeleted);
        }
    }
}