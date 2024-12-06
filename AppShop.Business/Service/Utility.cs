using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Service
{
    public  class Utility
    {
        public static string GetMsgRequired(string nameField)
        {
            return $"وارد کردن {nameField} اجباری است";
        }
        public static string GetMsgRepert(string nameField)
        {
            return $"{nameField} تکراری است";
        }
        public static string NotFoundProduct => "کالای مورد نظر یافت نشد";
    }
}
