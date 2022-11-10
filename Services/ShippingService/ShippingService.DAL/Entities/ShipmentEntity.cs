using ShippingService.DAL.Entities.Enums;
using ShippingService.DAL.Entities.Interfaces;

namespace ShippingService.DAL.Entities
{
    public class ShipmentEntity : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<TrackingEntity>? Tracking { get; set; }
    }
}
