using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.BLL.Handlers.Commands;
using StockManagement.BLL.Handlers.Queries;

namespace StockManagement.BLL
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
                typeof(CreateProductCommandHandler).Assembly, 
                typeof(GetAllProductQueryHandler).Assembly
                );
        }
    }
}
