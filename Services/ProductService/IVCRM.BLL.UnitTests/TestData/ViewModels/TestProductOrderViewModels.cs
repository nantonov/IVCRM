using IVCRM.API.ViewModels;

namespace IVCRM.BLL.UnitTests.TestData.ViewModels
{
    internal static class TestProductOrderViewModels
    {
        internal static OrderItemViewModel OrderItemViewModel => new()
        {
            ProductId = 1,
            OrderId = 1,
            Price = 1,
            Quantity = 1,
            Product = TestProductViewModels.ValidProductViewModel,
        };

        internal static List<OrderItemViewModel> ProductOrderViewModelCollection => new()
        {
            OrderItemViewModel,
        };
    }
}
