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
    public class LogService:ILogService
    {
        AppShopDBContext db;    
        public LogService(AppShopDBContext _db) {
        db= _db;
        }
        public void Add(string message ,string stackTrace)
        {
            var entity=new Log();
            entity.Massege= message;
            entity.CreateDateTime= DateTime.Now;
            entity.UserId= 1;
            db.Logs.Add(entity);
            db.SaveChanges();
            throw new Exception(message);
        }
    }
}
