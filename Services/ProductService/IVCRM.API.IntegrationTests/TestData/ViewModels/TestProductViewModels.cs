using IVCRM.API.ViewModels;

namespace IVCRM.API.IntegrationTests.TestData.ViewModels
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

        internal static ProductViewModel UpdatedProductViewModel => new()
        {
            Id = 1,
            Name = "UpdatedName",
            Price = 1,
            CategoryId = 1,
        };

        internal static List<ProductViewModel> ValidProductViewModelCollection => new()
        {
            new ()
            {
                Name = "Name1",
                Price = 1,
                CategoryId = 1,
            },
            new ()
            {
                Name = "Name2",
                Price = 1,
                CategoryId = 1,
            },
            new ()
            {
                Name = "Name3",
                Price = 1,
                CategoryId = 1,
            },
        };

        internal static ChangeProductViewModel ValidChangeProductViewModel => new()
        {
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        internal static ChangeProductViewModel UpdatedChangeProductViewModel => new()
        {
            Name = "UpdatedName",
            Price = 1,
            CategoryId = 1,
        };
    }
}
