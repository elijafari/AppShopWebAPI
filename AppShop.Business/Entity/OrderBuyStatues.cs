using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class OrderBuyStatues:BaseEntity
    {
        public int IdOrder { get; set; }
        public DateTime DateStatues { get; set; }
        public int Statues { get; set; }
        public virtual OrderBuy  OrderBuy {get; set; }
    }
}
