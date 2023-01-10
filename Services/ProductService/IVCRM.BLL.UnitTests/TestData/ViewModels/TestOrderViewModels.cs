using IVCRM.API.ViewModels;
using IVCRM.API.ViewModels.Enums;
using IVCRM.BLL.Models;

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

        internal static OrderDetailsViewModel OrderDetailsViewModel => new()
        {
            Id = 1,
            Name = "Name",
            OrderStatus = OrderStatus.Created,
            CustomerId = 1,
            Customer = TestCustomerViewModels.ValidCustomerViewModel,
            ProductOrders = TestProductOrderViewModels.ProductOrderViewModelCollection,
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
