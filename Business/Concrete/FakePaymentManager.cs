using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class FakePaymentManager : IPaymentService
    {
        public IResult Payment() //Test
        {
            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}