using FluentValidation;
using StockManagement.API.ViewModels;

namespace StockManagement.API.Validators
{
    public class ChangeProductValidator :AbstractValidator<ChangeProductViewModel>
    {
        public ChangeProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 250);
            RuleFor(x => x.Price).NotNull().GreaterThan(0);
            RuleFor(x => x.CategoryId).NotNull().GreaterThan(0);
        }
    }
}
