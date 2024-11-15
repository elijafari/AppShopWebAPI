using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.DataModel
{
    public class DataRequest
    {
        public DataRequest(int pageNumber, int take)
        {
            PageNumber = pageNumber;
            Take = take;
        }

        public int PageNumber { get;  set; }
        public int Take { get;  set; }
        

    }
}
