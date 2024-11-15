using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class Category: BaseEntity
    {
        public int? ParentId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }  
        public bool IsActive { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
