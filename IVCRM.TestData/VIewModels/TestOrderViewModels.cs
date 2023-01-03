using IVCRM.API.ViewModels;
using IVCRM.API.ViewModels.Enums;

namespace IVCRM.TestData.ViewModels
{
    public static class TestOrderViewModels
    {
        public static OrderViewModel ValidOrderViewModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        public static OrderViewModel UpdatedOrderViewModel => new()
        {
            Name = "UpdatedName",
            OrderStatus = OrderStatus.InProgress,
            CustomerId = 1,
        };

        public static List<OrderViewModel> ValidOrderViewModelCollection => new()
        {
            ValidOrderViewModel,
        };

        public static ChangeOrderViewModel ValidChangeOrderViewModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            OrderDate = DateTime.MaxValue,
            CustomerId = 1,
        };

        public static ChangeOrderViewModel UpdatedChangeOrderViewModel => new()
        {
            Name = "UpdatedName",
            OrderStatus = OrderStatus.InProgress,
            OrderDate = DateTime.Now,
            CustomerId = 1,
        };
    }
}
