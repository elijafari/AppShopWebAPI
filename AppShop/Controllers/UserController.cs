using AppShop.Business.Entity;
using AppShop.Business.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using AppShop.Business.DataModel;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Authorization;
using AppShop.Business.IService;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService service;
        private readonly ILogService logService;
//private readonly ICookiService cookiService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserController(IUserService _service, ILogService _logService,IHttpContextAccessor _httpContextAccessor)
        {
            service = _service;
            logService = _logService;
 //           cookiService = _cookiService;
            httpContextAccessor = _httpContextAccessor;

        }
        [HttpPost]
        public IActionResult Add(User entity)
        {
            try
            {
                service.Add(entity);
               // var resultAuth = cookiService.SetAuthentication(entity);
                ////HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(resultAuth.ClaimsIdentity));
                ////HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                ////  new ClaimsPrincipal(resultAuth.ClaimsIdentity),
                ////  new AuthenticationProperties());
                ////Request.Cookies.Add(new Cookie());
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] InUser input)
        {
            try
            {
                var user = service.Get(input.UserName, input.Password);
               // var resultAuth = cookiService.SetAuthentication(user);
         //       HttpContext.User.AddIdentity(resultAuth.ClaimsIdentity);
         //await httpContextAccessor.  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(resultAuth.ClaimsIdentity));
                //await  httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                //        new ClaimsPrincipal(resultAuth.ClaimsIdentity));

//                var claims = new List<Claim>
//{
//    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//    new Claim(ClaimTypes.Name, user.UserName),
//    new Claim(ClaimTypes.Email, user.Email)
//    // add or remove claims as necessary    
//};

//                    AllowRefresh = true,
//                var claimsIdentity = new ClaimsIdentity(claims, "MyAuthScheme");
//                var authProperties = new AuthenticationProperties
//                {
//                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
//                    IsPersistent = true,
//                };
                
//                 httpContextAccessor.HttpContext.SignInAsync("MyAuthScheme",new ClaimsPrincipal(claimsIdentity), authProperties);
//                //await httpContextAccessor.HttpContext
//                //    .SignInAsync("MyAuthScheme",
//                //        new ClaimsPrincipal(claimsIdentity),
//                //        authProperties);
//                var isid = httpContextAccessor.HttpContext.User.Identity;
                return Ok(user);
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                await httpContextAccessor. HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
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