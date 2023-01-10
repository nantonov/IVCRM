using IVCRM.DAL.Entities.Interfaces;
using IVCRM.DAL.Enums;

namespace IVCRM.DAL.Entities
{
    public class OrderEntity : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }

        public CustomerEntity? Customer { get; set; }
        public ICollection<OrderItemEntity>? OrderItems { get; set; }
    }
}
