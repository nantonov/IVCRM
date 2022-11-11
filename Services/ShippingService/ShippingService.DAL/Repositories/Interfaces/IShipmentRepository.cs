using ShippingService.DAL.Entities;

namespace ShippingService.DAL.Repositories.Interfaces
{
    public interface IShipmentRepository
    {
        Task<ShipmentEntity> Create(ShipmentEntity entity);
        Task<ShipmentEntity?> GetByOrderId(int orderId);
    }
}
