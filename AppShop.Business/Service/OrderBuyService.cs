using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AppShop.Business.Mapping;
using AppShop.Business.Service.IService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;
        public OrderBuyService(AppShopDBContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;

        }
        public decimal Add(InOrderBuy input)
        {
            var entity = mapper.Map<OrderBuy>(input);
            entity.IdUser = 1;
            entity.DateOrder = DateTime.Now;
            entity.Statues = (int)ShopStatues.Register;
            entity.ItemBuys.AddRange(mapper.Map<List<ItemBuy>>(input.Items));
            db.OrderBuys.Add(entity);
            db.SaveChanges();
            return entity.TrackingCode;
        }
        public void ChangeShopStatues(int id , ShopStatues shopStatues)
        {
            var entity = db.OrderBuys.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                entity.Statues = (int)ShopStatues.Confirm;
                db.OrderBuys.Update(entity);
                db.SaveChanges();
            }
            else
                throw new Exception(Utility.NotFoundProduct);
        }
    }
}
