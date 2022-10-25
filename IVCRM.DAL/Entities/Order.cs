using IVCRM.DAL.Enums;

namespace IVCRM.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
