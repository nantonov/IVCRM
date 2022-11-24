using IVCRM.BLL.Models;

namespace IVCRM.API.IntegrationTests.TestData.Models
{
    internal static class TestProductCategoryModels
    {
        internal static ProductCategory ProductCategoryModel => new()
        {
            Name = "Name",
        };

        internal static List<ProductCategory> ProductCategoryModelCollection => new()
        {
            ProductCategoryModel,
        };
    }
}
