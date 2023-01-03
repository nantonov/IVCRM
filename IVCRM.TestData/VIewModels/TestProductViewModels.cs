using IVCRM.API.ViewModels;

namespace IVCRM.TestData.ViewModels
{
    public static class TestProductViewModels
    {
        public static ProductViewModel ValidProductViewModel => new()
        {
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        public static ProductViewModel UpdatedProductViewModel => new()
        {
            Name = "UpdatedName",
            Price = 2,
            CategoryId = 1,
        };

        public static List<ProductViewModel> ValidProductViewModelCollection => new()
        {
            ValidProductViewModel,
        };

        public static ChangeProductViewModel ValidChangeProductViewModel => new()
        {
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        public static ChangeProductViewModel UpdatedChangeProductViewModel => new()
        {
            Name = "UpdatedName",
            Price = 2,
            CategoryId = 1,
        };
    }
}
