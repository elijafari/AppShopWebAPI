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
using Microsoft.AspNetCore.Identity;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<User> signInManager = null;
        private readonly UserManager<User> userManager = null;
        public UserController(SignInManager<User> sm, UserManager<User> um)
        {
            signInManager = sm;
            userManager = um;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(Login user)
        {

            IdentityResult result = new();

            try
            {
                User user_ = new User()
                {
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                     Address = user.Address,
                      City = user.City,
                };

                result = await userManager.CreateAsync(user_, user.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong, please try again. " + ex.Message);
            }

            return Ok(new { message = "Registered Successfully.", result = result });
        }

        [HttpPost("registerUserAdmin")]
        public async Task<ActionResult> RegisterUserAdmin()
        {

            IdentityResult result = new();

            try
            {
                User user_ = new User()
                {
                    Name = "Admin1",
                    Email ="e.jafari64@gmail.com",
                    UserName = "Admin",
                    Address = "افسریه",
                    City = "تهران",
                    NormalizedEmail="",
                };

                result = await userManager.CreateAsync(user_,"Admin_1231");

                if (!result.Succeeded)
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong, please try again. " + ex.Message);
            }

            return Ok(new { message = "Registered Successfully.", result = result });
        }
        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(Login login)
        {

            try
            {
                User user_ = await userManager.FindByNameAsync(login.UserName);
                if (user_ != null)
                {
                    login.UserName = user_.UserName;

                    if (!user_.EmailConfirmed)
                    {
                        user_.EmailConfirmed = true;
                    }

                    var result = await signInManager.PasswordSignInAsync(user_, login.Password, false, false);

                    if (!result.Succeeded)
                    {
                        return Unauthorized(new { message = "Check your login credentials and try again" });
                    }

                    user_.LastLogin = DateTime.Now;
                    var updateResult = await userManager.UpdateAsync(user_);
                }
                else
                {
                    return BadRequest(new { message = "Please check your credentials and try again. " });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong, please try again. " + ex.Message });
            }

            return Ok(new { message = "Login Successful." });
        }

        [HttpGet("logout"), Authorize]
        public async Task<ActionResult> LogoutUser()
        {

            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Someting went wrong, please try again. " + ex.Message });
            }

            return Ok(new { message = "You are free to go!" });
        }

        [HttpGet("xhtlekd")]
        public async Task<ActionResult> CheckUser()
        {
            User currentuser = new();

            try
            {
                var user = HttpContext.User;
                var principals = new ClaimsPrincipal(user);
                var result = signInManager.IsSignedIn(principals);
                if (result)
                {
                    currentuser = await signInManager.UserManager.GetUserAsync(principals);
                }
                else
                {
                    return Forbid();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong please try again. " + ex.Message });
            }

            return Ok(new { message = "Logged in", user = currentuser });
        }

    }
}
