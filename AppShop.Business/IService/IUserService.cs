using AppShop.Business.Entity;

namespace AppShop.Business.IService
{
    public interface IUserService
    {
        void Add(User entity);
        User Get(string userName, string passWord);
    }
}