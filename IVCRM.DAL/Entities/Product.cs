using System.ComponentModel.DataAnnotations;

namespace IVCRM.DAL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory? Category { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }
        public ICollection<ProductStorage>? ProductStorages { get; set; }
    }
}
