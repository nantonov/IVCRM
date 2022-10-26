using IVCRM.DAL.Enums;

namespace IVCRM.DAL.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity? Customer { get; set; }
        public ICollection<ProductOrderEntity>? ProductOrders { get; set; }
    }
}
