﻿using AppShop.Business.Entity;

namespace AppShop.Business.Service.IService
{
    public interface IUserService
    {
        void Add(User entity);
        User Get(string userName, string passWord);
    }
}