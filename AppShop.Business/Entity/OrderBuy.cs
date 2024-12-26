using AppShop.Business.Service;
using EnumsNET;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class OrderBuy:BaseEntity
    {
        public OrderBuy()
        {
            OrderBuyStatues = new List<OrderBuyStatues>();
        }
        public Guid UserId { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public ShopStatues Statues { get; set; }
        public decimal TrackingCode { get; set; }
        public virtual User UserEntity { get; set; }
        public virtual List<ItemBuy> ItemBuys { get; set; }
        public virtual List<OrderBuyStatues> OrderBuyStatues { get; set; }
        [NotMapped]
        public string StrStatues { get { return Statues.GetEnumDescription(); } }


    }
}
