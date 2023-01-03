using IVCRM.BLL.Models;
using IVCRM.BLL.Models.Enums;

namespace IVCRM.TestData.Models
{
    public static class TestOrderModels
    {
        public static Order OrderModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        public static Order UpdatedOrderModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            OrderDate = DateTime.MaxValue,
            CustomerId = 1,
        };

        public static List<Order> OrderModelCollection => new()
        {
            OrderModel,
        };
    }
}
