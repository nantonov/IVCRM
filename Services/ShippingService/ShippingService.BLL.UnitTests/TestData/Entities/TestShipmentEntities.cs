using ShippingService.DAL.Entities;
using ShippingService.DAL.Entities.Enums;

namespace ShippingService.BLL.UnitTests.TestData.Entities
{
    internal static class TestShipmentEntities
    {

        internal static ShipmentEntity ShipmentEntity => new()
        {
            Id = new Guid(1, 0, 0, new byte[8]),
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
