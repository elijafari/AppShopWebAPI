using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
   public class Log:BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Massege { get; set; }
    }
}
