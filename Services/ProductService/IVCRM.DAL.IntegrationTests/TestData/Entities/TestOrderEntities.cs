using IVCRM.DAL.Entities;
using IVCRM.DAL.Enums;

namespace IVCRM.DAL.IntegrationTests.TestData.Entities
{
    internal static class TestOrderEntities
    {
        internal static OrderEntity OrderEntity => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        internal static OrderEntity UpdatedOrderEntity => new()
        {
            Name = "UpdatedName",
            OrderStatus = OrderStatus.InProgress,
            CustomerId = 1,
        };

        internal static List<OrderEntity> OrderEntityCollection => new ()
        {
            OrderEntity,
        };
    }
}
