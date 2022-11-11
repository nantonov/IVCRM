using ShippingService.DAL.Entities;
using ShippingService.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShippingService.DAL.Models;

namespace ShippingService.DAL.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly IMongoCollection<ShipmentEntity> _shipmentCollection;

        public ShipmentRepository(IOptions<DatabaseSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _shipmentCollection = database.GetCollection<ShipmentEntity>(mongoDBSettings.Value.ShipmentCollectionName);
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
