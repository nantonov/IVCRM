using MongoDB.Driver;
using ShippingService.DAL.Entities;
using ShippingService.DAL.Entities.Interfaces;
using ShippingService.DAL.Extensions;

namespace ShippingService.DAL.IntegrationTests.Infrastructure
{
    public class IntegrationTestsBase : IDisposable
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "ShippingDB_test";

        protected IMongoDatabase Context { get; } = new MongoClient(ConnectionString).GetDatabase(DatabaseName);
        protected IMongoCollection<ShipmentEntity> ShipmentCollection
        {
            get
            {
                return Context.GetCollection<ShipmentEntity>(typeof(ShipmentEntity).GetCollectionName());
            }
        }

        public async Task<Guid> AddToContext<T>(T entity) where T : class, IEntity
        {
            var collectionName = entity.GetType().GetCollectionName();
            var dbSet = Context.GetCollection<T>(collectionName);
            await dbSet.InsertOneAsync(entity);

            return entity.Id;
        }

        public void Dispose()
        {
            Context.Client.DropDatabase(DatabaseName);
        }
    }
}
