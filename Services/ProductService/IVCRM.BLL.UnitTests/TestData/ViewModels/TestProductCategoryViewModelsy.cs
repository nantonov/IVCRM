using IVCRM.API.ViewModels;

namespace IVCRM.BLL.UnitTests.TestData.ViewModels
{
    internal static class TestProductCategoryViewModels
    {
        internal static ProductCategoryViewModel ValidProductCategoryViewModel => new()
        {
            Id = 1,
            Name = "Name",
            ChildCategories = new List<ProductCategoryViewModel>()
        };

        internal static ChangeProductCategoryViewModel ValidChangeProductCategoryViewModel => new()
        {
            Name = "Name",
        };
    }
}
