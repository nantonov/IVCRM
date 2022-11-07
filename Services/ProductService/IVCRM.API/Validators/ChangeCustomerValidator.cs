using FluentValidation;
using IVCRM.API.ViewModels;

namespace IVCRM.API.Validators
{
    public class ChangeCustomerValidator :AbstractValidator<ChangeCustomerViewModel>
    {
        public ChangeCustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotNull().NotEmpty().Length(1, 250);
            RuleFor(customer => customer.LastName).NotNull().NotEmpty().Length(1, 250);
            RuleFor(customer => customer.PhoneNumber).NotEmpty().WithMessage("Please add a phone number");
        }
    }
}
