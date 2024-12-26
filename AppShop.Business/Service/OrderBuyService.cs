using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AppShop.Business.IService;
using AppShop.Business.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Service
{
    public class OrderBuyService : IOrderBuyService
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
            entity.UserId = Guid.NewGuid();
            entity.DateOrder = DateTime.Now;
            entity.Statues = ShopStatues.Register;
            entity.ItemBuys.AddRange(mapper.Map<List<ItemBuy>>(input.Items));

            var statues = new OrderBuyStatues();
            statues.Statues = ShopStatues.Register;
            statues.DateStatues = DateTime.Now;
            entity.OrderBuyStatues.Add(statues);

            db.OrderBuys.Add(entity);
            db.SaveChanges();


            return entity.TrackingCode;
        }
        public void ChangeShopStatues(int id, ShopStatues shopStatues)
        {
            var entity = db.OrderBuys.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                var statues = new OrderBuyStatues();
                statues.Statues = shopStatues;
                statues.DateStatues = DateTime.Now;
                entity.OrderBuyStatues.Add(statues);

                entity.Statues = shopStatues;
                db.OrderBuys.Update(entity);
                db.SaveChanges();
            }
            else
                throw new Exception(Utility.NotFoundProduct);
        }
        public DataView GetAll(DataRequest param)
        {
            var result = new DataView(param.Take, param.PageNumber);
            result.Data = db.OrderBuys.OrderByDescending(x => x.DateOrder).Skip(result.StartRow).Take(param.Take).Cast<object>().ToList();
            result.TotalCount = db.Products.Count();
            return result;
        }
        public DataView GetAllUser(DataRequest param, Guid userId)
        {
            var result = new DataView(param.Take, param.PageNumber);
            result.Data = db.OrderBuys.Where(x => x.UserId == userId).Skip(result.StartRow).Take(param.Take).Cast<object>().ToList();
            result.TotalCount = db.Products.Count();
            return result;
        }
        public OrderBuy GetById(int id)
        {
            return db.OrderBuys.Where(x => x.Id == id).SingleOrDefault();
        }
        public List<KeyValue> GetDays()
        {
            var result = new List<KeyValue>();
            for (int i = 0; i < 7; ++i)
            {
                var date = DateTime.Now.AddDays(i);
                result.Add(new KeyValue(date, Utility.GetPersion(date) + " " + Utility.GetDay(date)));
            }
            return result;
        }
    }
}
