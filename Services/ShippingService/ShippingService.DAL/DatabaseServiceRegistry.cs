using ShippingService.DAL.Repositories.Interfaces;
using ShippingService.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ShippingService.BLL
{
    public static class DatabaseServiceRegistry
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IShipmentRepository, ShipmentRepository>();
        }
    }
}
