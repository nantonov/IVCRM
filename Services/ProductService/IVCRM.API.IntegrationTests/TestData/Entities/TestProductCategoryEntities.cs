using IVCRM.DAL.Entities;

namespace IVCRM.API.IntegrationTests.TestData.Entities
{
    internal static class TestProductCategoryEntities
    {
        internal static ProductCategoryEntity ProductCategoryEntity => new()
        {
            Name = "Name",
        };

        internal static ProductCategoryEntity UpdatedProductCategoryEntity => new()
        {
            Name = "UpdatedName",
        };

        internal static List<ProductCategoryEntity> ProductCategoryEntityCollection => new()
        {
            new () {Name = "Name1"},
            new () {Name = "Name2"},
            new () {Name = "Name3"},
        };
    }
}
