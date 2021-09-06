using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Tab
    {
        public Tab()
        {
            Quantity = 1;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public short Quantity { get; set; } 
        public decimal UnitPrice { get; set; }
        public decimal SubPrice => Quantity * UnitPrice;
    }
}
