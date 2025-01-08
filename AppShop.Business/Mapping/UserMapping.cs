using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppShop.Business.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
          
            builder.ToTable("Users");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Address).IsRequired().HasColumnType("nvarchar(1000)");         
            builder.Property(p => p.City).IsRequired().HasColumnType("nvarchar(50)");         
            builder.Property(p => p.Email).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.CreatedDate).IsRequired().HasColumnType("nvarchar(50)");         
            builder.Property(p => p.ModifiedDate).HasColumnType("nvarchar(50)");
            builder.Property(p => p.LastLogin).HasColumnType("nvarchar(50)");
            builder.Property(p => p.PasswordHash).IsRequired().HasColumnType("nvarchar(100)"); 
            builder.Property(p => p.NormalizedEmail).IsRequired().HasColumnType("nvarchar(50)"); 
            builder.Property(p => p.IsAdmin).HasDefaultValue(false);


        }
    }
}
