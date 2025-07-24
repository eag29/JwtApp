using Eag.Jwt.Onion.Core.Domain.Entities;
using Eag.Jwt.Onion.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Infrastructure.Persistence.Context
{
    public class JwtContext: DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<AppRole>? AppRoles { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
