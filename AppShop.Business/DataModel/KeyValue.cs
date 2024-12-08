using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.DataModel
{
    public class KeyValue
    {
        public KeyValue(object _key,string _value) {
         Key = _key;
            Value = _value;
        
        }
        public object Key { get; set; }
       public string Value { get; set; }
    }
}
