using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ShippingService.DAL.Entities;
using ShippingService.DAL.Entities.Interfaces;
using ShippingService.DAL.Extensions;

namespace ShippingService.API.IntegrationTests.Infrastructure
{
    public class IntegrationTestsBase : IDisposable
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "ShippingDB_test";

        public IntegrationTestsBase()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>

            builder.ConfigureServices(services =>
            {
                var dbService = services.SingleOrDefault(x =>
                    x.ServiceType == typeof(IMongoDatabase));
                services.Remove(dbService!);

                services.AddSingleton(new MongoClient(ConnectionString).GetDatabase(DatabaseName));
            }));
            Server = factory.Server;
            Client = Server.CreateClient();
            Context = factory.Services.CreateScope().ServiceProvider.GetService<IMongoDatabase>()!;
        }

        protected TestServer Server { get; }
        protected HttpClient Client { get; }
        protected IMongoDatabase Context { get; }

        protected IMongoCollection<ShipmentEntity> ShipmentCollection { get
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
