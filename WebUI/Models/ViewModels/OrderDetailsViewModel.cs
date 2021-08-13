using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public List<OrderDetailsDTO> OrderDetails { get; set; }
    }
}
