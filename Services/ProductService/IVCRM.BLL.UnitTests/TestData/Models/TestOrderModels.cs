using IVCRM.BLL.Models;
using IVCRM.BLL.Models.Enums;

namespace IVCRM.BLL.UnitTests.TestData.Models
{
    internal static class TestOrderModels
    {
        internal static Order OrderModel => new()
        {
            Id = 1,
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        internal static OrderDetails OrderDetailsModel => new()
        {
            Id = 1,
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
            Customer = TestCustomerModels.CustomerModel,
            OrderItems = TestProductOrderModels.ProductOrderModelCollection

        };

        internal static List<Order> OrderModelCollection => new()
        {
            OrderModel,
        };
    }
}
