using IVCRM.BLL.Models;

namespace IVCRM.BLL.UnitTests.TestData.Models
{
    internal static class TestProductModels
    {
        internal static Product ProductModel => new()
        {
            Id = 1,
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        internal static List<Product> ProductModelCollection => new()
        {
            ProductModel,
        };
    }
}
