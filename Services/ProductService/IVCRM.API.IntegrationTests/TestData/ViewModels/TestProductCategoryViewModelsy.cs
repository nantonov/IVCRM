using IVCRM.API.ViewModels;

namespace IVCRM.API.IntegrationTests.TestData.ViewModels
{
    internal static class TestProductCategoryViewModels
    {
        internal static ProductCategoryViewModel ValidProductCategoryViewModel => new()
        {
            Name = "Name",
            ChildCategories = new List<ProductCategoryViewModel>()
        };

        internal static ProductCategoryViewModel UpdatedProductCategoryViewModel => new()
        {
            Name = "UpdatedName",
            ChildCategories = new List<ProductCategoryViewModel>()
        };

        internal static List<ProductCategoryViewModel> ValidProductCategoryViewModelCollection => new()
        {
            new () { Name = "Name1", ChildCategories = new List<ProductCategoryViewModel>() },
            new () { Name = "Name2", ChildCategories = new List<ProductCategoryViewModel>() },
            new () { Name = "Name3", ChildCategories = new List<ProductCategoryViewModel>() },
        };

        internal static ChangeProductCategoryViewModel ValidChangeProductCategoryViewModel => new()
        {
            Name = "Name",
        };

        internal static ChangeProductCategoryViewModel InvalidChangeProductCategoryViewModel => new();

        internal static ChangeProductCategoryViewModel UpdatedChangeProductCategoryViewModel => new()
        {
            Name = "UpdatedName",
        };
    }
}
