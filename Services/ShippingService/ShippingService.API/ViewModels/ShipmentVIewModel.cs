using ShippingService.API.ViewModels.Enums;

namespace ShippingService.API.ViewModels
{
    public class ShipmentViewModel
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
