using IVCRM.DAL.Entities;
using IVCRM.DAL.Enums;

namespace IVCRM.TestData.Entities
{
    public static class TestOrderEntities
    {
        public static OrderEntity OrderEntity => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        public static OrderEntity UpdatedOrderEntity => new()
        {
            Name = "UpdatedName",
            OrderStatus = OrderStatus.InProgress,
            CustomerId = 1,
        };

        public static List<OrderEntity> OrderEntityCollection => new ()
        {
            OrderEntity,
        };
    }
}
