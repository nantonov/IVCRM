using ShippingService.BLL.Handlers.Commands;
using ShippingService.BLL.Models.Enums;

namespace ShippingService.BLL.UnitTests.TestData.Commands
{
    internal static class TestShipmentCommands
    {
        internal static CreateShipmentCommand ValidCreateShipmentCommand => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };
    }
}
