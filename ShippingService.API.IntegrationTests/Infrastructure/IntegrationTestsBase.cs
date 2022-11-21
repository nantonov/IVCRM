using ShippingService.DAL.Entities.Interfaces;
using ShippingService.DAL.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ShippingService.API.IntegrationTests.Infrastructure
{
    public class IntegrationTestsBase : IDisposable
    {
        private const string ConfigurationKey = "DatabaseConfigs:ConnectionString";
        private const string ConnectionString = "Server=mssql;Database=SportService_db;User Id=sa;Password=StrPassword123;";

        public IntegrationTestsBase()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
                builder.ConfigureServices(services =>
                {
                    var dbContextService = services.SingleOrDefault(x =>
                        x.ServiceType == typeof(DbContextOptions<AppDbContext>));
                    services.Remove(dbContextService!);

                    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));
                }));
            Server = factory.Server;
            Client = Server.CreateClient();
            Context = factory.Services.CreateScope().ServiceProvider.GetService<AppDbContext>()!;
        }

        protected TestServer Server { get; }
        protected HttpClient Client { get; }
        protected AppDbContext Context { get; }


        public async Task<int> AddToContext<T>(T entity) where T : class, IEntity
        {
            var dbSet = Context.Set<T>();
            await dbSet.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task AddRangeToContext<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            var dbSet = Context.Set<T>();
            await dbSet.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
