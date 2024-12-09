using AppShop.Business.DataModel;
using AppShop.Business.Entity;

namespace AppShop.Business.Service.IService
{
    public interface IOrderBuyService
    {
        decimal Add(InOrderBuy input);
        void ChangeShopStatues(int id, ShopStatues shopStatues);
        DataView GetAll(DataRequest param);
        DataView GetAllUser(DataRequest param, int userId);
        OrderBuy GetById(int id);
        List<KeyValue> GetDays();
    }
}