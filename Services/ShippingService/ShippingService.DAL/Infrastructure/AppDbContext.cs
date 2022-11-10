using ShippingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShippingService.DAL.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ShipmentEntity> Shipment { get; set; } = null!;
        public DbSet<TrackingEntity> Tracking { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackingEntity>().HasOne(x => x.Shipment).WithMany(x => x.Tracking).HasForeignKey(x => x.ShipmentId);
        }
    }
}
