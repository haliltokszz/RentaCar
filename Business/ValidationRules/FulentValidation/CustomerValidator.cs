using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FulentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.DriveExperience).NotEmpty();
            RuleFor(c => c.DriveExperience).GreaterThan(2);
        }
    }
}