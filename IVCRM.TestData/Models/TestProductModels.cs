using IVCRM.BLL.Models;

namespace IVCRM.TestData.Models
{
    public static class TestProductModels
    {
        public static Product ProductModel => new()
        {
            Name = "Name",
            Price = 1,
            CategoryId = 1,
        };

        public static List<Product> ProductModelCollection => new()
        {
            ProductModel,
        };
    }
}
