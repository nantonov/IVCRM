using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShippingService.BLL.Handlers.Commands;
using ShippingService.BLL.Handlers.Queries;

namespace ShippingService.BLL
{
    public static class ServiceCollectionRegistry
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSetup(configuration);
            services.AddRepositories();
        }

        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(CreateShipmentCommandHandler).Assembly, 
                typeof(GetShipmentByOrderIdQueryHandler).Assembly
                );
        }
    }
}
