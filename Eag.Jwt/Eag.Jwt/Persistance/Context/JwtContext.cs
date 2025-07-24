using Eag.Jwt.Core.Domain;
using Eag.Jwt.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Eag.Jwt.Persistance.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<AppRole> AppRoles => Set<AppRole>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
    }
}
