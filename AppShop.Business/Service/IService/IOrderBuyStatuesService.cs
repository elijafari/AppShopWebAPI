using AppShop.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Service.IService
{
    public interface IOrderBuyStatuesService
    {
        List<OrderBuyStatues> GetById(int orderBuyId);
    }
}
