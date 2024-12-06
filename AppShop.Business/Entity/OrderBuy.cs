using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class OrderBuy:BaseEntity
    {
        public OrderBuy()
        {
                ItemBuys=new List<ItemBuy>();
        }
        public int IdUser { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public int Statues { get; set; }
        public decimal TrackingCode { get; set; }
        public virtual User UserEntity { get; set; }
        public virtual List<ItemBuy> ItemBuys { get; set; }

    }
}
