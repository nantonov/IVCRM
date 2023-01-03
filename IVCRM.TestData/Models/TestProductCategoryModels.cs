using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;

namespace IVCRM.TestData.Models
{
    public static class TestProductCategoryModels
    {
        public static ProductCategory ProductCategoryModel => new()
        {
            Name = "Name",
        };

        public static List<ProductCategory> ProductCategoryModelCollection => new()
        {
            ProductCategoryModel,
        };
    }
}
