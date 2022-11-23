using ShippingService.DAL.Repositories.Interfaces;
using ShippingService.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace ShippingService.BLL
{
    public static class DatabaseServiceRegistry
    {
        private const string SectionName = "DatabaseSettings";
        private const string ConnectionString = "ConnectionString";
        private const string DatabaseName = "DatabaseName";
        public static void AddMongoDbSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSection = configuration.GetSection(SectionName);
            var connectionString = mongoSection.GetSection(ConnectionString).Value;
            var databaseName = mongoSection.GetSection(DatabaseName).Value;
            

            services.AddSingleton(new MongoClient(connectionString).GetDatabase(databaseName));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IShipmentRepository, ShipmentRepository>();
        }
    }
}
