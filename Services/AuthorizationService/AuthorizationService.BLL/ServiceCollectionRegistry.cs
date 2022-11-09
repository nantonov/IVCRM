using AuthorizationService.DAL;
using AuthorizationService.DAL.Infrastructure;
using IdentityServer4.Configuration;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPWB.AuthorizationService.Dependencies.Configs;
using System.Data;
using AuthorizationService.BLL.Validators;
using AuthorizationService.BLL.Services;

namespace IVCRM.BLL
{
    public static class ServiceCollectionRegistry
    {
        private const int HourTokenCleanupInterval = 3600;
        private const string ConnectionString = "MSSQLSERVER";
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSetup(configuration);
        }

        public static void AddIdentitySetup(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthServiceDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddIdentityServerSetup(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
                .AddInMemoryClients(IdentityServerConfig.Clients)
                .AddDeveloperSigningCredential()
                .AddProfileService<ProfileService>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();
        }
    }
}
