using AppShop.Business.Entity;
using AppShop.Business.Service;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using AppShop.Business.DataModel;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService service;
        private readonly ILogService logService;
        private readonly ICookiService cookiService;
        public UserController(IUserService _service, ILogService _logService, ICookiService cookiService)
        {
            service = _service;
            logService = _logService;
            cookiService = cookiService;
        }
        [HttpPost]
        public IActionResult Add(User entity)
        {
            try
            {
                service.Add(entity);
                cookiService.SetCooki(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(InUser input)
        {
            try
            {
               var entity= service.Get(input.UserName,input.Password);
                cookiService.SetCooki(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}