using IVCRM.DAL.Entities;

namespace IVCRM.API.IntegrationTests.TestData.Entities
{
    internal static class TestProductEntities
    {
        internal static ProductEntity ProductEntity => new()
        {
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        internal static ProductEntity UpdatedProductEntity => new()
        {
            Name = "UpdatedName",
            Price = 1,
            CategoryId = 1,
        };

        internal static List<ProductEntity> ProductEntityCollection => new()
        {
            new () { Name = "Name1", Price = 1, CategoryId = 1 },
            new () { Name = "Name2", Price = 1, CategoryId = 1 },
            new () { Name = "Name3", Price = 1, CategoryId = 1 },
        };
    }
}
