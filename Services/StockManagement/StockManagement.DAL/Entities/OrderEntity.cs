using StockManagement.DAL.Entities.Interfaces;
using StockManagement.DAL.Enums;

namespace StockManagement.DAL.Entities
{
    public class OrderEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public ICollection<ProductOrderEntity>? ProductOrders { get; set; }
    }
}
