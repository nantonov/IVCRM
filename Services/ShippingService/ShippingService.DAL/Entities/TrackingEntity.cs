using MongoDB.Bson.Serialization.Attributes;

namespace ShippingService.DAL.Entities
{
    public class TrackingEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
