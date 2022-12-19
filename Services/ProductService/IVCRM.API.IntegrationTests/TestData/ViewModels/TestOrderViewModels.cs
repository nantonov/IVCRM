using IVCRM.API.ViewModels;
using IVCRM.API.ViewModels.Enums;

namespace IVCRM.API.IntegrationTests.TestData.ViewModels
{
    internal static class TestOrderViewModels
    {
        internal static OrderViewModel ValidOrderViewModel => new()
        {
            Id = 1,
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        internal static OrderViewModel UpdatedOrderViewModel => new()
        {
            Id = 1,
            Name = "UpdatedName",
            OrderStatus = OrderStatus.InProgress,
            CustomerId = 1,
        };

        internal static List<OrderViewModel> ValidOrderViewModelCollection => new()
        {
            new ()
            {
                Id = 1,
                Name = "Name1",
                OrderStatus = OrderStatus.Created,
                CustomerId = 1,
            },
            new ()
            {
                Id = 1,
                Name = "Name2",
                OrderStatus = OrderStatus.Created,
                CustomerId = 1,
            },
            new ()
            {
                Id = 1,
                Name = "Name3",
                OrderStatus = OrderStatus.Created,
                CustomerId = 1,
            },
        };

        internal static ChangeOrderViewModel ValidChangeOrderViewModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            OrderDate = DateTime.Now,
            CustomerId = 1,
        };

        internal static ChangeOrderViewModel UpdatedChangeOrderViewModel => new()
        {
            Name = "UpdatedName",
            OrderStatus = OrderStatus.InProgress,
            OrderDate = DateTime.Now,
            CustomerId = 1,
        };
    }
}
