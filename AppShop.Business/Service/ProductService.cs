using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AppShop.Business.Mapping;
using AppShop.Business.Service.IService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Service
{
    public class ProductService : IProductService
    {
        AppShopDBContext db;
        private readonly IMapper mapper;
        public ProductService(AppShopDBContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;

        }
        public void Add(InProduct input)
        {
            var entity = mapper.Map<Product>(input);
            entity.IsActive=true;
            ValidtionData(entity);
            db.Products.Add(entity);
            db.SaveChanges();
        }
        public void Update(Product entity)
        {
            ValidtionData(entity);
            db.Products.Update(entity);
            db.SaveChanges();
        }

        private void ValidtionData(Product entity)
        {
            if (entity.Code == 0)
            {
                throw new Exception(Utility.GetMsgRequired("کد"));
            }
            else if (db.Products.Any(x => x.Code == entity.Code && x.Id!=entity.Id))
            {
                throw new Exception(Utility.GetMsgRepert("کد"));
            }
            if (entity.Name == null || entity.Name.Length == 0)
            {
                throw new Exception(Utility.GetMsgRequired("نام"));
            }

            else if (db.Products.Any(x => x.Name == entity.Name && x.Id != entity.Id))
            {
                throw new Exception(Utility.GetMsgRepert("نام"));
            }
            if (entity.CategoryId == 0)
            {
                throw new Exception(Utility.GetMsgRequired("گروه کالا"));

            }
            if (entity.Price == 0)
            {
                throw new Exception(Utility.GetMsgRequired("قیمت"));
            }
            if (entity.image == null)
            {
                throw new Exception(Utility.GetMsgRequired("عکس"));
            }
        }

        public DataView GetAll(DataRequest param)
        {
            var result = new DataView(param.Take, param.PageNumber);
            result.Data = db.Products.OrderBy(x => x.Code).Skip(result.StartRow).Take(param.Take).Cast<object>().ToList();
            result.TotalCount = db.Products.Count();
            return result;
        }
    }
}
