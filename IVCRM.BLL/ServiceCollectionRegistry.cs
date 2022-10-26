using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.BLL
{
    public static class ServiceCollectionRegistry
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSetup(configuration);
        }
    }
}
