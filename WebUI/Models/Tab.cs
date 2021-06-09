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
            Amount = 1;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public short Amount { get; set; } 
        public decimal SubPrice { get; set; }
        public decimal TotalPrice => Amount * SubPrice;
    }
}
