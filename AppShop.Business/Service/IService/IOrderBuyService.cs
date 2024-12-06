using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AutoMapper;

namespace AppShop.Business.Service.IService
{
    public interface IOrderBuyService
    {
        decimal Add(InOrderBuy input);
        void ChangeShopStatues(int id, ShopStatues shopStatues);
    }
}