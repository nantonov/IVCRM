using IVCRM.API.ViewModels;

namespace IVCRM.TestData.ViewModels
{
    public static class TestProductCategoryViewModels
    {
        public static ProductCategoryViewModel ValidProductCategoryViewModel => new()
        {
            Name = "Name",
            ChildCategories = new List<ProductCategoryViewModel>(),
        };

        public static ProductCategoryViewModel UpdatedProductCategoryViewModel => new()
        {
            Name = "UpdatedName",
            ChildCategories = new List<ProductCategoryViewModel>(),
        };

        public static List<ProductCategoryViewModel> ValidProductCategoryViewModelCollection => new()
        {
            new () { Name = "Name1", ChildCategories = new List<ProductCategoryViewModel>() },
            new () { Name = "Name2", ChildCategories = new List<ProductCategoryViewModel>() },
            new () { Name = "Name3", ChildCategories = new List<ProductCategoryViewModel>() },
        };

        public static ChangeProductCategoryViewModel ValidChangeProductCategoryViewModel => new()
        {
            Name = "Name",
        };

        public static ChangeProductCategoryViewModel InvalidChangeProductCategoryViewModel => new();

        public static ChangeProductCategoryViewModel UpdatedChangeProductCategoryViewModel => new()
        {
            Name = "UpdatedName",
        };
    }
}
