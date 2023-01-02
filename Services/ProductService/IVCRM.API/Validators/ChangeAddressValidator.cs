using FluentValidation;
using IVCRM.API.ViewModels;

namespace IVCRM.API.Validators
{
    public class ChangeAddressValidator :AbstractValidator<ChangeAddressViewModel>
    {
        public ChangeAddressValidator()
        {
            RuleFor(address => address.Street).NotNull().NotEmpty().Length(1, 250);
            RuleFor(address => address.City).NotNull().NotEmpty().Length(1, 250);
            RuleFor(address => address.State).NotNull().NotEmpty().Length(1, 250);
            RuleFor(address => address.ZipCode).NotNull().NotEmpty().Length(1, 250);
        }
    }
}
