using Eag.Jwt.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eag.Jwt.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUsers).HasForeignKey(x => x.AppRoleId);
        }
    }
}
