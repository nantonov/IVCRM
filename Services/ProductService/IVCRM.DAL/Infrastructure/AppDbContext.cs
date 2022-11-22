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
        public DbSet<OrderEntity> Orders { get; set; } = null!;
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; } = null!;
        public DbSet<ProductOrderEntity> ProductOrders { get; set; } = null!;
        public DbSet<ProductStorageEntity> ProductStorages { get; set; } = null!;
        public DbSet<StorageEntity> Storages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(p => p.Property(x => x.Price).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<ProductEntity>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<ProductCategoryEntity>().HasOne(x => x.ParentCategory).WithMany(x => x.ChildCategories).HasForeignKey(x => x.ParentCategoryId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductOrderEntity>(p => p.Property(x => x.Price).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<ProductOrderEntity>().HasKey(x => new { x.ProductId, x.OrderId});
            modelBuilder.Entity<ProductOrderEntity>().HasOne(x => x.Order).WithMany(x => x.ProductOrders).HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<ProductOrderEntity>().HasOne(x => x.Product).WithMany(x => x.ProductOrders).HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<ProductStorageEntity>().HasKey(x => new { x.ProductId, x.StorageId });
            modelBuilder.Entity<ProductStorageEntity>().HasOne(x => x.Storage).WithMany(x => x.ProductStorages).HasForeignKey(x => x.StorageId);
            modelBuilder.Entity<ProductStorageEntity>().HasOne(x => x.Product).WithMany(x => x.ProductStorages).HasForeignKey(x => x.ProductId);
        }
    }
}
