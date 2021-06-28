using Core.Entities;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Models.ViewModels
{
    public class HomepageViewModel
    {
        public ResponseDTO<List<Product>> Products { get; set; }
        public ResponseDTO<TablesStatusDTO> TableStatus { get; set; }
        public ResponseDTO<decimal> OrderAmounts { get; set; }
        public ResponseDTO<List<Order>> LastOrders { get; set; }
        public Person Person { get; set; }
    }
}
