using FluentValidation;
using IVCRM.API.ViewModels;

namespace IVCRM.API.Validators
{
    public class ChangeOrderValidator :AbstractValidator<ChangeOrderViewModel>
    {
        public ChangeOrderValidator()
        {
            RuleFor(order => order.Name).NotNull().NotEmpty().Length(1, 250);
            RuleFor(order => order.OrderDate).NotNull().NotEmpty();
            RuleFor(order => order.OrderStatus).IsInEnum();
            RuleFor(order => order.CustomerId).NotNull().NotEmpty();
        }
    }
}
