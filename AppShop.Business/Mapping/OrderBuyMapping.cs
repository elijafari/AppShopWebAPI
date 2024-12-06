using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppShop.Business.Mapping
{
    public class OrderBuyMapping : IEntityTypeConfiguration<OrderBuy>
    {
        public void Configure(EntityTypeBuilder<OrderBuy> builder)
        {
          
            builder.ToTable("OrderBuy");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.IdUser).IsRequired();
            builder.Property(p => p.DateDelivery).IsRequired();
            builder.Property(p => p.Statues).IsRequired();
            builder.Property(p => p.DateOrder).IsRequired();
            builder.Property(p => p.TrackingCode).UseIdentityColumn(1001);

        }
    }
}
