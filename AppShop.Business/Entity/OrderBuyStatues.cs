using AppShop.Business.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class OrderBuyStatues:BaseEntity
    {
        public int IdOrder { get; set; }
        public DateTime DateStatues { get; set; }
        public ShopStatues Statues { get; set; }
        public virtual OrderBuy  OrderBuy {get; set; }
        [NotMapped]
        public string StrStatues { get { return Statues.GetEnumDescription(); } }
        [NotMapped]
        public string PersionDate { get { return Utility.GetPersion(DateStatues); } }
    }
}
