using ShippingService.BLL.Handlers.Commands;
using ShippingService.BLL.Models.Enums;

namespace ShippingService.API.IntegrationTests.TestData.Commands
{
    internal static class TestShipmentCommands
    {
        internal static CreateShipmentCommand CreateShipmentCommand => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };
    }
}
