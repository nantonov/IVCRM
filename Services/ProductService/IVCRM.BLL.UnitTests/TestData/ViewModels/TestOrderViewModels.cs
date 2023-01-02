using IVCRM.API.ViewModels;
using IVCRM.API.ViewModels.Enums;

namespace IVCRM.BLL.UnitTests.TestData.ViewModels
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

        internal static ChangeOrderViewModel ValidChangeOrderViewModel => new()
        {
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
        };

        internal static List<OrderViewModel> OrderViewModelCollection => new()
        {
            ValidOrderViewModel,
        };
    }
}
