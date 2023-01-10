using IVCRM.BLL.Services;
using IVCRM.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.BLL
{
    public static class ServiceCollectionRegistry
    {
        private const string AzureConnectionString = "AzureBlobStorage";
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var azureConnectionString = configuration.GetConnectionString(AzureConnectionString);

            services.AddEntityFrameworkSetup(configuration);
            services.AddRepositories();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IPictureService> (x => new AzurePictureService(azureConnectionString));
        }
    }
}
