using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class OrderBuy:BaseEntity
    {
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public string TimeDelivery { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int Statues { get; set; }
        public virtual User UserEntity { get; set; }
        public virtual Product ProductEntity { get; set; }

    }
}
