using ShippingService.DAL.Entities;
using ShippingService.DAL.Entities.Enums;

namespace ShippingService.API.IntegrationTests.TestData.Entities
{
    internal static class TestShipmentEntities
    {

        internal static ShipmentEntity ShipmentEntity => new()
        {
            OrderId = 1,
            ShipmentStatus = ShipmentStatus.Preliminary,
            ShippingAddress = "ShippingAddress",
        };

        internal static List<ShipmentEntity> ShipmentEntityCollection => new ()
        {
            ShipmentEntity,
        };
    }
}
