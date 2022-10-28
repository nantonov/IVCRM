using IVCRM.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.DAL.IntegrationTests.Infrastructure
{
    public class IntegrationTestsBase : IDisposable
    {
        protected AppDbContext Context { get; } = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("DalTestDb").Options);

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
