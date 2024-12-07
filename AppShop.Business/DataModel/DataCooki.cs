using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AppShop.Business.DataModel
{
    public class DataCooki
    {
        public DataCooki()
        {
        }

        public ClaimsIdentity ClaimsIdentity { get; internal set; }
        public AuthenticationProperties AuthProperties { get; internal set; }
    }
}