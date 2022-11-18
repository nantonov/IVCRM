using FluentValidation;
using ShippingService.API.ViewModels;
using ShippingService.API.ViewModels.Enums;

namespace ShippingService.API.Validators
{
    public class ChangeShipmentValidator :AbstractValidator<ChangeShipmentViewModel>
    {
        public ChangeShipmentValidator()
        {
            RuleFor(x => x.OrderId).NotNull();
            RuleFor(x => x.ShipmentStatus).IsInEnum();
            RuleFor(x => x.ShippingAddress).NotNull().NotEmpty().Length(3, 250);
        }
    }
}
