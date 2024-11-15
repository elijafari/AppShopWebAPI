using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppShop.Business.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
          
            builder.ToTable("User");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Family).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.PostalCode).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Password).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.City).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Email).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Phone).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.PhoneNumber).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Address).IsRequired().HasColumnType("nvarchar(1000)");
            builder.Property(p => p.Type).IsRequired();

        }
    }
}
