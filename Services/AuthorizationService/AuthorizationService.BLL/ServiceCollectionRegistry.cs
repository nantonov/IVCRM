using AuthorizationService.DAL;
using AuthorizationService.DAL.Entities;
using AuthorizationService.DAL.Infrastructure;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuthorizationService.BLL.Configs;

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

        public static void AddIdentitySetup(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AuthServiceDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddIdentityServerSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddConfigurationStore<AuthServiceDbContext>(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(configuration.GetConnectionString(ConnectionString));
                })
                .AddOperationalStore<AuthServiceDbContext>(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(configuration.GetConnectionString(ConnectionString));
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = HourTokenCleanupInterval;
                })
                .AddDeveloperSigningCredential();
        }

        public static void InitializeDatabase(this IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            var context = serviceScope?.ServiceProvider.GetRequiredService<AuthServiceDbContext>();
            var userManager = serviceScope?.ServiceProvider.GetRequiredService<UserManager<User>>();

            if (context is not null)
            {
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in IdentityServerConfig.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }

                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resources in IdentityServerConfig.IdentityResources)
                    {
                        context.IdentityResources.Add(resources.ToEntity());
                    }

                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var scope in IdentityServerConfig.ApiScopes)
                    {
                        context.ApiScopes.Add(scope.ToEntity());
                    }

                    context.SaveChanges();
                }

                var testUser = IdentityServerConfig.TestUser;

                if (userManager?.FindByNameAsync(testUser.UserName) == null)
                {
                    userManager?.CreateAsync(testUser, testUser.UserName);
                }
            }
        }
    }
}
