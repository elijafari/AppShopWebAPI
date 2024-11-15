using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string UserName { get; set; }
        public int Type { get; set; }

    }
}
