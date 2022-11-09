using ShippingService.API.ViewModels.Enums;

namespace ShippingService.API.ViewModels
{
    public class ChangeShipmentViewModel
    {
        public int OrderId { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
