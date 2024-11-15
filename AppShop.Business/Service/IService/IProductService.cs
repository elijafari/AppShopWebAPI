using AppShop.Business.DataModel;
using AppShop.Business.Entity;

namespace AppShop.Business.Service.IService
{
    public interface IProductService
    {
        void Add(Product entity);
        void Update(Product entity);
        DataView GetAll(DataRequest param);
    }
}