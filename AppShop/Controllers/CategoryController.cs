using AppShop.Business.Entity;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService service;
        private readonly ILogService logService;
        public CategoryController(ICategoryService _service,ILogService _logService)
        {
            service = _service;
            logService = _logService;
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

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message , ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}