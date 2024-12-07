using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Service
{
    public class CookiService: ICookiService
    {
        public DataCooki SetAuthentication(User user)
        {
            var result = new DataCooki();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim("FullName", $"{user.Name} {user.Family}"),
            new Claim(ClaimTypes.Role, user.Type.ToString()),
        };

           result.ClaimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            result.AuthProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };
            return result;
        }

        //public void SingOut()
        //{
        //    HttpContext.SignOutAsync(
        //    CookieAuthenticationDefaults.AuthenticationScheme);

        //}
    }
}
