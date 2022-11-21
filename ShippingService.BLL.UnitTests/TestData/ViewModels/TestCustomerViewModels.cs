using ShippingService.API.ViewModels;
using ShippingService.API.ViewModels.Enums;

namespace IVCRM.BLL.UnitTests.TestData.ViewModels
{
    internal static class TestShipmentViewModels
    {
        internal static ShipmentViewModel ShipmentViewModel => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };

        internal static List<ShipmentViewModel> CustomerViewModelCollection => new()
        {
            new ()
            {
                OrderId = 1,
                ShipmentStatus = ShipmentStatus.Preliminary,
                ShippingAddress = "ShippingAddress1",
            },
            new ()
            {
                OrderId = 1,
                ShipmentStatus = ShipmentStatus.Preliminary,
                ShippingAddress = "ShippingAdderess2",
            },
            new ()
            {
                OrderId = 1, 
                ShipmentStatus = ShipmentStatus.Preliminary, 
                ShippingAddress = "ShippingAddress3",
            },
        };

        internal static ChangeShipmentViewModel ChangeCustomerViewModel => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddres",
        };
    }
}
