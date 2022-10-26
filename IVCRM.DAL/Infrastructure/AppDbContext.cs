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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ProductStorage> ProductStorages { get; set; }
        public DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(x => x.Customer).WithMany(x => x.Orders);
            modelBuilder.Entity<Product>(p => p.Property(x => x.Price).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<ProductOrder>(p => p.Property(x => x.Price).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<ProductOrder>().HasKey(x => new { x.ProductId, x.OrderId});
            modelBuilder.Entity<ProductOrder>().HasOne(x => x.Order).WithMany(x => x.ProductOrders).HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<ProductOrder>().HasOne(x => x.Product).WithMany(x => x.ProductOrders).HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<ProductStorage>().HasKey(x => new { x.ProductId, x.StorageId });
            modelBuilder.Entity<ProductStorage>().HasOne(x => x.Storage).WithMany(x => x.ProductStorages).HasForeignKey(x => x.StorageId);
            modelBuilder.Entity<ProductStorage>().HasOne(x => x.Product).WithMany(x => x.ProductStorages).HasForeignKey(x => x.ProductId);
        }
    }
}
