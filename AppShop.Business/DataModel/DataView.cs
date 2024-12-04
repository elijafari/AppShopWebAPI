using AppShop.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.DataModel
{
    public class DataView
    {
        public DataView(int take,int pageNumber)
        {
            this.Take = take;
            this.PageNumber = pageNumber-1;
        }
        private int Take { get; set; }
        public List<object>  Data { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageCount => SetPageCount();
        public int StartRow=>SetStartNumber();

       private int SetPageCount()
        {
            if(Take==0) return 0;
            return TotalCount % Take == 0 ? TotalCount / Take : (TotalCount / Take) + 1;
        }
        private int SetStartNumber()
        {
            return (PageNumber* Take);
        }
    }
}
