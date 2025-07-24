using Eag.Jwt.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eag.Jwt.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
