using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.TestData.Entities
{
    internal static class TestProductEntities
    {
        internal static ProductEntity ProductEntity => new()
        {
            Id = 1,
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        internal static List<ProductEntity> ProductEntityCollection => new()
        {
            ProductEntity,
        };
    }
}
