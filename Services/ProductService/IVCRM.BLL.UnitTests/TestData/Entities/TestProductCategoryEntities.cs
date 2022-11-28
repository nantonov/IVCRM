using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.TestData.Entities
{
    internal static class TestProductCategoryEntities
    {
        internal static ProductCategoryEntity ProductCategoryEntity => new()
        {
            Id = 1,
            Name = "Name",
            ChildCategories = new List<ProductCategoryEntity>(),
        };

        internal static List<ProductCategoryEntity> ProductCategoryEntityCollection => new ()
        {
            ProductCategoryEntity,
        };
    }
}
