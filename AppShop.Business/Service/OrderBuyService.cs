using AppShop.Business.Entity;
using AppShop.Business.Mapping;
using AppShop.Business.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Service
{
    public class OrderBuyService:IOrderBuyService
    {
        AppShopDBContext db;    
        public OrderBuyService(AppShopDBContext _db) {
        db= _db;
        }
        public void Add(OrderBuy entity)
        {
            db.OrderBuys.Add(entity);
            db.SaveChanges();
        }
    }
}
