using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppShop.Business.Mapping
{
    public class OrderBuyStatuesMapping : IEntityTypeConfiguration<OrderBuyStatues>
    {
        public void Configure(EntityTypeBuilder<OrderBuyStatues> builder)
        {
          
            builder.ToTable("OrderBuyStatues");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.IdOrder).IsRequired();
            builder.Property(p => p.DateStatues).IsRequired();
            builder.Property(p => p.Statues).IsRequired();

        }
    }
}
