using IVCRM.DAL.Entities;
using IVCRM.DAL.Enums;

namespace IVCRM.BLL.UnitTests.TestData.Entities
{
    internal static class TestOrderEntities
    {
        internal static OrderEntity OrderEntity => new()
        {
            Id = 1,
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        internal static List<OrderEntity> OrderEntityCollection => new ()
        {
            OrderEntity,
        };
    }
}
