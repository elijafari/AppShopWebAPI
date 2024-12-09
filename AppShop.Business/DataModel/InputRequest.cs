using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.DataModel
{
    public class InputRequest
    {
        public int PageNumber { get; set; }
        public Filter Filter { get; set; }

    }
    public class Filter
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int FromPrice { get; set; }
        public int ToPrice { get; set; }
    }
}
