using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppShop.Business.Mapping
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
          
            builder.ToTable("Log");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.CreateDateTime).IsRequired();
            builder.Property(p => p.Massege).IsRequired().HasColumnType("nvarchar(1000)");

        }
    }
}
