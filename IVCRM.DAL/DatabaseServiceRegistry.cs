using IVCRM.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.BLL
{
    public static class DatabaseServiceRegistry
    {
        private const string ConnectionString = "MSSQLSERVER";

        public static void AddEntityFrameworkSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionString);
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
