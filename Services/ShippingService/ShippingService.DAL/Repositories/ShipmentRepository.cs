using ShippingService.DAL.Infrastructure;
using ShippingService.DAL.Entities;
using ShippingService.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ShippingService.DAL.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly AppDbContext _context;

        public ShipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ShipmentEntity> Create(ShipmentEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _context.Shipment.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public async Task<ShipmentEntity?> GetByOrderId(int orderId)
        {
            return await _context.Shipment.AsNoTracking().FirstOrDefaultAsync(x => x.OrderId == orderId);
        }
    }
}
