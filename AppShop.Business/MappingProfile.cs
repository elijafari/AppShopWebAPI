using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AutoMapper;

namespace AppShop.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<InProduct, Product>();
            CreateMap<InOrderBuy, OrderBuy>();
        }
    }
}