using MediatR;
using ShippingService.BLL.Models;
using ShippingService.BLL.Models.Enums;

namespace ShippingService.BLL.Handlers.Commands
{
    public class CreateShipmentCommand : IRequest<Shipment>
    {
        public int OrderId { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
