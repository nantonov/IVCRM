using ShippingService.BLL.Models;
using ShippingService.BLL.Models.Enums;

namespace ShippingService.API.IntegrationTests.TestData.Entities
{
    internal static class TestShipmentModels
    {
        internal static Shipment Shipment => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };

        internal static List<Shipment> ShipmentCollection => new()
        {
            Shipment,
        };
    }
}
