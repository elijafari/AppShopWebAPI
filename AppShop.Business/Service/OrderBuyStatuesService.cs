﻿using AppShop.Business.DataModel;
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
    public class OrderBuyStatuesService : IOrderBuyStatuesService
    {
        AppShopDBContext db;
        private readonly IMapper mapper;
        public OrderBuyStatuesService(AppShopDBContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;

        }
       public List<OrderBuyStatues> GetById(int orderBuyId)
        {
            return db.OrderBuys.Where(x => x.OrderBuyId == orderBuyId).SingleOrDefault();
        }
    }
}
