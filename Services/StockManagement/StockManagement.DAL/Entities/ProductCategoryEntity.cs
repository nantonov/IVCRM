using StockManagement.DAL.Entities.Interfaces;

namespace StockManagement.DAL.Entities
{
    public class ProductCategoryEntity : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductEntity>? Products { get; set; }
    }
}
