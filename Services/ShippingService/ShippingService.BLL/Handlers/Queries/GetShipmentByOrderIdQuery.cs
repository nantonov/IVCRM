using MediatR;
using ShippingService.BLL.Models;

namespace ShippingService.BLL.Handlers.Queries
{
    public class GetShipmentByOrderIdQuery : IRequest<Shipment>
    {
        public GetShipmentByOrderIdQuery(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; set; }
    }
}
