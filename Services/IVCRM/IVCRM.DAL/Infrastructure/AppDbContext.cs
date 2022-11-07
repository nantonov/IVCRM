using IVCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.DAL.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CustomerEntity> Customers { get; set; } = null!;
    }
}
