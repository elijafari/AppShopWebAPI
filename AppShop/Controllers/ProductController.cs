using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AppShop.Business.Service;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService service;
        private readonly ILogService logService;
        public ProductController(IProductService _service, ILogService _logService)
        {
            service = _service;
            logService = _logService;
        }

        [HttpPost]
        public IActionResult Add(Product entity)
        {
            try
            {
                service.Add(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message + "///" + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        //[HttpPost]
        //public void Add()
        //{
        //    //for (int i = 0; i < 1000; i++)
        //    //{
        //    //    service.Add(new Product()
        //    //    {
        //    //        Name = "لامپ 100",
        //    //        CategoryId = 1,
        //    //        Code = 1 + i,
        //    //        Price = 100 * (i + 1)
        //    //    });
        //    //}

        //}
        [HttpPost]
        public ActionResult GetAll(InputRequest inputRequest)
        {
            try
            {
                var param = new DataRequest(inputRequest.PageNumber,20);
                return Ok(service.GetAll(param));
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message + "///" + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult GetAllAdmin(InputRequest inputRequest)
        {
            //push 25 aban 1403

            try
            {
                var param = new DataRequest(inputRequest.PageNumber, 100);
                return Ok(service.GetAll(param));
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message + "///" + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}