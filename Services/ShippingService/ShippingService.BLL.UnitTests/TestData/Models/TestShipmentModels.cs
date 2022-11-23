using ShippingService.BLL.Models;
using ShippingService.BLL.Models.Enums;

namespace ShippingService.BLL.UnitTests.TestData.Entities
{
    internal static class TestShipmentModels
    {
        internal static Shipment ValidShipmentModel => new()
        {
            Id = new Guid(1, 0, 0, new byte[8]),
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };

        internal static List<Shipment> ValidShipmentCollection => new()
        {
            ValidShipmentModel,
        };
    }
}
