using StockManagement.DAL.Infrastructure;
using StockManagement.DAL.Repositories.Interfaces;
using StockManagement.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StockManagement.BLL
{
    public static class DatabaseServiceRegistry
    {
        private const string ConnectionString = "MSSQLSERVER";

        public static void AddEntityFrameworkSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionString);
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
