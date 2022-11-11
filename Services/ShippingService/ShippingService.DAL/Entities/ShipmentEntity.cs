using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ShippingService.DAL.Entities.Enums;

namespace ShippingService.DAL.Entities
{
    public class ShipmentEntity
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
