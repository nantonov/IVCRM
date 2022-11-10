using ShippingService.DAL.Entities.Interfaces;

namespace ShippingService.DAL.Entities
{
    public class TrackingEntity : IEntity
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }

        public ShipmentEntity? Shipment { get; set; }
    }
}
