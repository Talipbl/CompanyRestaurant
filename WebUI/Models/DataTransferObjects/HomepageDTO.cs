using Core.Entities;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.DataTransferObjects
{
    public class HomepageDTO
    {
        public List<Product> Products { get; set; }
        public TablesStatusDTO TableStatus { get; set; }
        public decimal OrderAmounts { get; set; }
        public List<Order> LastOrders { get; set; }
        public Person Person { get; set; }
    }
}
