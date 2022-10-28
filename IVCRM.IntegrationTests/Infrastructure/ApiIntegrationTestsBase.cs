using IVCRM.DAL.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IVCRM.IntegrationTests.Infrastructure
{
    public class ApiIntegrationTestsBase : IDisposable
    {
        public ApiIntegrationTestsBase()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
                builder.ConfigureServices(services =>
                {
                    var dbContextService = services.SingleOrDefault(x =>
                        x.ServiceType == typeof(DbContextOptions<AppDbContext>));
                    services.Remove(dbContextService!);

                    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ApiTestDb"));
                }));
            Server = factory.Server;
            Client = Server.CreateClient();
            Context = factory.Services.CreateScope().ServiceProvider.GetService<AppDbContext>()!;
        }

        protected TestServer Server { get; }
        protected HttpClient Client { get; }
        protected AppDbContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
