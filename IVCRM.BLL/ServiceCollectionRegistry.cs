using IVCRM.BLL.Services;
using IVCRM.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.BLL
{
    public static class ServiceCollectionRegistry
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSetup(configuration);
            services.AddRepositories();

            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
