using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.TestData.Entities
{
    internal static class TestProductOrderEntities
    {
        internal static OrderItemEntity OrderItemEntity => new()
        {
            ProductId = 1,
            OrderId = 1,
            Price = 1,
            Quantity = 1,
            Product = TestProductEntities.ProductEntity,
        };

        internal static List<OrderItemEntity> ProductOrderEntityCollection => new()
        {
            OrderItemEntity,
        };
    }
}
