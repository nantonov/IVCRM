using ShippingService.BLL.Models;

namespace ShippingService.BLL.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<Shipment> Create(Shipment entity);
        Task<Shipment?> GetByOrderId(int orderId);
    }
}
