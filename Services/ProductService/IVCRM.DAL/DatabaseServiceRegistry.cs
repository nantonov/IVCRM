using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Repositories.Interfaces;
using IVCRM.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.BLL
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
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
        }
    }
}
