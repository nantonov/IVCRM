using IVCRM.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVCRM.BLL
{
    public static class ServiceCollectionRegistry
    {
        private const string ConnectionString = "ConnectionString";
        public static void AddServices(this IServiceCollection services)
        {
        }

        public static void AddEntityFrameworkSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionString);
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
