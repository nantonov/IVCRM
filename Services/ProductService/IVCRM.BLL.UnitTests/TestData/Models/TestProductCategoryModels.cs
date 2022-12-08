using IVCRM.BLL.Models;

namespace IVCRM.BLL.UnitTests.TestData.Models
{
    internal static class TestProductCategoryModels
    {
        internal static ProductCategory ProductCategoryModel => new()
        {
            Id = 1,
            Name = "Name",
            ChildCategories = new List<ProductCategory>(),
        };

        internal static List<ProductCategory> ProductCategoryModelCollection => new()
        {
            ProductCategoryModel,
        };
    }
}
