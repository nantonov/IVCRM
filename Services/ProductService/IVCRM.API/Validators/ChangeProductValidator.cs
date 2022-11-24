using FluentValidation;
using IVCRM.API.ViewModels;

namespace IVCRM.API.Validators
{
    public class ChangeProductValidator :AbstractValidator<ChangeProductViewModel>
    {
        public ChangeProductValidator()
        {
            RuleFor(product => product.Name).NotNull().NotEmpty().Length(1, 250);
            RuleFor(product => product.Price).NotNull().NotEmpty();
            RuleFor(product => product.CategoryId).NotNull().NotEmpty();
        }
    }
}
