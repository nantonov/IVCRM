using IVCRM.API.ViewModels;

namespace IVCRM.BLL.UnitTests.TestData.ViewModels
{
    internal static class TestProductViewModels
    {
        internal static ProductViewModel ValidProductViewModel => new()
        {
            Id = 1,
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        internal static ChangeProductViewModel ValidChangeProductViewModel => new()
        {
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };
    }
}
