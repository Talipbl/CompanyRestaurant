using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Models.ViewModels
{
    public class ListProductsViewModel
    {
        public ResponseDTO<List<ProductsDTO>> Products{ get; set; }
    }
}
