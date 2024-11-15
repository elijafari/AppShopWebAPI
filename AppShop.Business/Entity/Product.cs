using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Entity
{
    public class Product: BaseEntity
    { 
        public int CategoryId { get; set;}
        public int Code { get; set; }
        public string Name { get; set; }  
        public bool IsActive { get; set; }     
        public string? Description { get; set; }
        public byte[]? image { get; set; }
        public int Price { get; set; }
        public virtual Category CategoryEntity { get; set; }


    }
}
