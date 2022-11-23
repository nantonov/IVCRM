using ShippingService.DAL.Entities;
using ShippingService.DAL.Repositories.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using ShippingService.DAL.Attributes;
using ShippingService.DAL.Extensions;

namespace ShippingService.DAL.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly IMongoCollection<ShipmentEntity> _shipmentCollection;

        public ShipmentRepository(IMongoDatabase db)
        {
            _shipmentCollection = db.GetCollection<ShipmentEntity>(typeof(ShipmentEntity).GetCollectionName());
        }

        public async Task<ShipmentEntity> Create(ShipmentEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _shipmentCollection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<ShipmentEntity> GetByOrderId(int orderId)
        {
            return await _shipmentCollection.Find(x => x.OrderId == orderId).SingleOrDefaultAsync();
        }
    }
}
