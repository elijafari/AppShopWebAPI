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
    public class CategoryService:ICategoryService
    {
        AppShopDBContext db;    
        public CategoryService(AppShopDBContext _db) {
        db= _db;
        }
        public void Add(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }
        public List<Category> GetAll(bool tagAll)
        {
          var list= db.Categories.OrderBy(c => c.Name).ToList();
            if(tagAll) 
                list.insert(0,new Category() { Id=0, Name="همه کالا ها"});
            return list;
        }
    }
}
