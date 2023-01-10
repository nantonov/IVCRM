using IVCRM.DAL.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace IVCRM.DAL.Entities
{
    public class ProductEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PictureUri { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public ProductCategoryEntity? Category { get; set; }
        public ICollection<OrderItemEntity>? OrderItems { get; set; }
        public ICollection<ProductStorageEntity>? ProductStorages { get; set; }
    }
}
