using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;

namespace AuthorizationService.DAL.Infrastructure
{
    public class AuthServiceDbContext : IdentityDbContext<IdentityUser, IdentityRole, int>, IPersistedGrantDbContext, IConfigurationDbContext
    {
        public AuthServiceDbContext(DbContextOptions<AuthServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
        public DbSet<ApiScope> ApiScopes { get; set; }
        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
        public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public DbSet<ApiResource> ApiResources { get ; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "1221")
            }
            );
        }
    }
}