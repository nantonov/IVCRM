using IVCRM.DAL.Entities;

namespace IVCRM.TestData.Entities
{
    public static class TestProductEntities
    {
        public static ProductEntity ProductEntity => new()
        {
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        public static ProductEntity UpdatedProductEntity => new()
        {
            Name = "UpdatedName",
            Price = 2,
            CategoryId = 1,
        };

        public static List<ProductEntity> ProductEntityCollection => new ()
        {
            ProductEntity,
        };
    }
}
