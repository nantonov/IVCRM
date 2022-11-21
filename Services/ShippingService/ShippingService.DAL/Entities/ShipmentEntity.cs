using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ShippingService.DAL.Attributes;
using ShippingService.DAL.Entities.Enums;
using ShippingService.DAL.Entities.Interfaces;

namespace ShippingService.DAL.Entities
{
    [BsonCollection("Shipment")]
    public class ShipmentEntity : IEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        [BsonRepresentation(BsonType.String)]
        public ShipmentStatus ShipmentStatus { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<TrackingEntity>? Tracking { get; set; }
    }
}
