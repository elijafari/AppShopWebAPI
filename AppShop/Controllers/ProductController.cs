using AppShop.Business;
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
        public IActionResult Add()
        {
            try
            {
                var input = ConvertToDto();
                service.Add(input);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Update()
        {
            try
            {
                var input = ConvertToDto();
                service.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private InProduct ConvertToDto()
        {

            InProduct input = new InProduct();

            var form = Request.Form;
            input.Id = int.Parse(form[nameof(input.Id).ToCamelCose()]);
            input.Code = int.Parse(form[nameof(input.Code).ToCamelCose()]);
            input.Name = form[nameof(input.Name).ToCamelCose()];
            input.Price = int.Parse(form[nameof(input.Price).ToCamelCose()]);
            input.Description = form[nameof(input.Description).ToCamelCose()];
            input.CategoryId = int.Parse(form[nameof(input.CategoryId).ToCamelCose()]);
            input.IsActive = bool.Parse(form[nameof(input.IsActive).ToCamelCose()]);

            if (Request.Form.Files.Any())
            {
                var file = Request.Form.Files[0];
                string extension = Path.GetExtension(file.FileName);
                //read the file
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    input.image = memoryStream.ToArray();
                }

            }
            return input;
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
                var param = new DataRequest(inputRequest.PageNumber, 20);
                return Ok(service.GetAll(param));
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
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
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public ActionResult GetById(int id)
        {
            try
            {
                return Ok(service.GetById(id));
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public ActionResult DeleteAll()
        {
            try
            {
                return Ok(service.DeleteAll());
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}