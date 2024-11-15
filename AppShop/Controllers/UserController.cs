using AppShop.Business.Entity;
using AppShop.Business.Service;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService service;
        private readonly ILogService logService;
        public UserController(IUserService _service, ILogService _logService)
        {
            service = _service;
            logService = _logService;
        }
        [HttpPost]
        public IActionResult Add(User entity)
        {
            try
            {
                service.Add(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message+"///"+ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}