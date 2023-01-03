using IVCRM.API.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.TestData.Entities
{
    public static class TestProductCategoryEntities
    {
        public static ProductCategoryEntity ProductCategoryEntity => new()
        {
            Name = "Name",
        };

        public static ProductCategoryEntity UpdatedProductCategoryEntity => new()
        {
            Name = "UpdatedName",
        };

        public static List<ProductCategoryEntity> ProductCategoryEntityCollection => new ()
        {
            new () { Name = "Name1" },
            new () { Name = "Name2" },
            new () { Name = "Name3" },
        };
    }
}
