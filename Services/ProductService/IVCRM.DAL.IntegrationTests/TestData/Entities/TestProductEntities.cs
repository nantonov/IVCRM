using IVCRM.DAL.Entities;

namespace IVCRM.DAL.IntegrationTests.TestData.Entities
{
    internal static class TestProductEntities
    {
        internal static ProductEntity ProductEntity => new()
        {
            Name = "Name",
        };

        internal static ProductEntity UpdatedProductEntity => new()
        {
            Name = "UpdatedName",
        };

        internal static List<ProductEntity> ProductEntityCollection => new ()
        {
            new () { Name = "Name1" },
            new () { Name = "Name2" },
            new () { Name = "Name3" },
        };
    }
}
