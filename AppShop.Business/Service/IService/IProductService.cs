using AppShop.Business.DataModel;
using AppShop.Business.Entity;

namespace AppShop.Business.Service.IService
{
    public interface IProductService
    {
        void Add(InProduct input);
        void Update(InProduct entity);
        DataView GetAll(DataRequest param);
        Product GetById(int id);
        bool DeleteAll();
    }
}