using AppShop.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.IService
{
    public interface ICategoryService
    {
        void Add(Category entity);
        List<Category> GetAll(bool tagAll);
    }
}
