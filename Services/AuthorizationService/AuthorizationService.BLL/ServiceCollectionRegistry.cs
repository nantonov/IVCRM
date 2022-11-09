using AuthorizationService.DAL;
using AuthorizationService.DAL.Infrastructure;
using IdentityServer4.Configuration;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorizationService.BLL
{
    public static class ServiceCollectionRegistry
    {
        private const int HourTokenCleanupInterval = 3600;
        private const string ConnectionString = "MSSQLSERVER";
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSetup(configuration);
        }
    }
}
