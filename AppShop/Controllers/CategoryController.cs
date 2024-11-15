using AppShop.Business.Entity;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService service;

        public CategoryController(ICategoryService _service)
        {
            service = _service;
        }
        [HttpPost]
        public void Add()
        {
            service.Add(new Category()
            {
                Name = "صنعتی",
                Code = 1,
            });
            service.Add(new Category()
            {
                Name = "خانگی",
                Code = 2,
            });
            service.Add(new Category()
            {
                Name = "A",
                Code = 3,
            });

        }
    }
}