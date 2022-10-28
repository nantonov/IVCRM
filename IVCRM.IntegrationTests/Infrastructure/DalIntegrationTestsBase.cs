using IVCRM.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.IntegrationTests.Infrastructure
{
    public class DalIntegrationTestsBase : IDisposable
    {
        protected AppDbContext Context { get; } = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("DalTestDb").Options);

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
