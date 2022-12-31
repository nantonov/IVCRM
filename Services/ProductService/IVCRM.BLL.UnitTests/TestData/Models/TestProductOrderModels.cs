using IVCRM.BLL.Models;

namespace IVCRM.BLL.UnitTests.TestData.Models
{
    internal static class TestProductOrderModels
    {
        internal static ProductOrder ProductOrderModel => new()
        {
            ProductId = 1,
            OrderId = 1,
            Price = 1,
            Quantity = 1,
            Product = TestProductModels.ProductModel,
        };

        internal static List<ProductOrder> ProductOrderModelCollection => new()
        {
            ProductOrderModel,
        };
    }
}
