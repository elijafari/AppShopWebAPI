using AppShop.Business.Entity;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderBuyController : ControllerBase
    {

        private readonly IOrderBuyService service;

        public OrderBuyController(IOrderBuyService _service)
        {
            service = _service;
        }
        [HttpPost]
        public void Add()
        {
        

        }
    }
}