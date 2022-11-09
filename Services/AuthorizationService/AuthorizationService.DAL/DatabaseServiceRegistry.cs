using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuthorizationService.DAL.Infrastructure;

namespace AuthorizationService.DAL
{
    public static class DatabaseServiceRegistry
    {
        private const string ConnectionString = "MSSQLSERVER";

        public static void AddEntityFrameworkSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionString);
            services.AddDbContext<AuthServiceDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
