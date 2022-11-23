using MongoDB.Bson.Serialization.Attributes;
using ShippingService.DAL.Attributes;
using ShippingService.DAL.Entities.Interfaces;

namespace ShippingService.DAL.Entities
{
    [BsonCollection("Tracking")]
    public class TrackingEntity : IEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
