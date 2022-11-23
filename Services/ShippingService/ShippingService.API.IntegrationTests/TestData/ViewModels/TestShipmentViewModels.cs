using ShippingService.API.ViewModels;
using ShippingService.API.ViewModels.Enums;

namespace ShippingService.API.IntegrationTests.TestData.ViewModels
{
    internal static class TestShipmentViewModels
    {
        internal static ShipmentViewModel InvalidShipmentViewModel => new();

        internal static ShipmentViewModel ValidShipmentViewModel => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };

        internal static List<ShipmentViewModel> ValidShipmentViewModelCollection => new()
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

        internal static ChangeShipmentViewModel ValidChangeShipmentViewModel => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };
    }
}
