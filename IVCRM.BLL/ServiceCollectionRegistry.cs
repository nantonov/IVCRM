using IVCRM.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.BLL
{
    public static class ServiceCollectionRegistry
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSetup(configuration);
        }
    }
}
