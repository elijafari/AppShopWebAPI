using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class ItemBuy:BaseEntity
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public virtual OrderBuy OrderBuyEntity { get; set; }

    }
}
