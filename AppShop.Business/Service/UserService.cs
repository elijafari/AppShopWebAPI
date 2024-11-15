﻿using AppShop.Business.Entity;
using AppShop.Business.Mapping;
using AppShop.Business.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Service
{
    public class UserService:IUserService
    {
        AppShopDBContext db;    
        public UserService(AppShopDBContext _db) {
        db= _db;
        }
        public void Add(User entity)
        {
            if(db.Users.Where(x=>x.UserName==entity.UserName).Any()) {
             throw new Exception("نام کاربری تکراری است");
            }
            db.Users.Add(entity);
            db.SaveChanges();
        }
    }
}
