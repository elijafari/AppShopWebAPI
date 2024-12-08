using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static string GetPersion(DateTime d)
        {
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));
        }
        public static string GetDay(DateTime d)
        {
            var result=string.Empty;
            switch (d.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    result = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    result = "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    result = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    result = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    result = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    result = "پنج شنبه";
                    break;
                case DayOfWeek.Friday:
                    result = "جمعه";
                    break;

            }
            return result;
        }
    }
}
