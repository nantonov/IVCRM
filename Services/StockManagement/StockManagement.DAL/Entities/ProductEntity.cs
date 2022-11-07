using StockManagement.DAL.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.DAL.Entities
{
    public class ProductEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategoryEntity? Category { get; set; }
        public ICollection<ProductOrderEntity>? ProductOrders { get; set; }
        public ICollection<ProductStorageEntity>? ProductStorages { get; set; }
    }
}
