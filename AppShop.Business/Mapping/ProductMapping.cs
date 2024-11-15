using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppShop.Business.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
          
            builder.ToTable("Product");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Code).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.CategoryId).IsRequired();         
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.image).IsRequired(false);
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");

        }
    }
}
