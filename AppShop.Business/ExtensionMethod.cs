using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business
{
    public static class ExtensionMethod
    {
        public static string ToCamelCose(this string  str) {
        
        return str.Substring(0,1).ToLower()+str.Substring(1);
        }
    }
}
