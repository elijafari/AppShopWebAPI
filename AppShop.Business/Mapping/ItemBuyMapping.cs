using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppShop.Business.Mapping
{
    public class ItemBuyMapping : IEntityTypeConfiguration<ItemBuy>
    {
        public void Configure(EntityTypeBuilder<ItemBuy> builder)
        {
          
            builder.ToTable("OrderBuyItem");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.IdOrder).IsRequired();
            builder.Property(p => p.IdProduct).IsRequired();
            builder.Property(p => p.Number).IsRequired();
            builder.Property(p => p.Price).IsRequired();

        }
    }
}
