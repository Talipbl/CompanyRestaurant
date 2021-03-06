using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;
using WebUI.Models.Managers;

namespace WebUI.Models.ViewModels
{
    public class OrderViewModel
    {
        public Order Order{ get; set; }
        public List<ProductsDTO> Products { get; set; }
        public TabManager TabManager { get; set; }
    }
}
