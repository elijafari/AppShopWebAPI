using AppShop.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.DataModel
{
    public class InOrderBuy
    {
        public DateTime DateDelivery { get; set; }
        public List<InItemBuy> Items { get; set; }
    }
    public class InItemBuy 
    {
        public int IdProduct { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
    }
    public class InId
    {
        public int Id { get; set; }
    }
}
