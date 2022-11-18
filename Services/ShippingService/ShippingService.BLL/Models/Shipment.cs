using ShippingService.BLL.Models.Enums;

namespace ShippingService.BLL.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
