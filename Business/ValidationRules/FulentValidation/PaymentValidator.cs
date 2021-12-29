using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FulentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(c => c.Owner).NotEmpty();
            RuleFor(c => c.Cvv).NotEmpty();
            RuleFor(c => c.Number).NotEmpty();
            RuleFor(c => c.ExpireMonth).NotEmpty();
            RuleFor(c => c.ExpireYear).NotEmpty();
        }
    }
}