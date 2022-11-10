using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using AuthorizationService.DAL.Entities;

namespace AuthorizationService.DAL.Infrastructure
{
    public class AuthServiceDbContext : IdentityDbContext<User, Role, int>, IPersistedGrantDbContext, IConfigurationDbContext
    {
        public AuthServiceDbContext(DbContextOptions<AuthServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<IdentityResource> IdentityResources { get; set; } = null!;
        public DbSet<ApiScope> ApiScopes { get; set; } = null!;
        public DbSet<PersistedGrant> PersistedGrants { get; set; } = null!;
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; } = null!;
        public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; } = null!;
        public DbSet<ApiResource> ApiResources { get ; set; } = null!;

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<DeviceFlowCodes>().ToTable("DeviceCode").HasKey(x => x.UserCode);
            builder.Entity<PersistedGrant>().ToTable(nameof(PersistedGrant)).HasKey(x => x.Key);
        }
    }
}