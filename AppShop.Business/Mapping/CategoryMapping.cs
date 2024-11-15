using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppShop.Business.Mapping
{
    public class CategoryMapping:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
          
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Code).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.ParentId).IsRequired(false);         
            builder.Property(p => p.IsActive).HasDefaultValue(true);


            builder.HasMany(p => p.Products).WithOne(p => p.CategoryEntity);
        }
    }
}
