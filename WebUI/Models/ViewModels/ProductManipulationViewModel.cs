using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Models.ViewModels
{
    public class ProductManipulationViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<string> Errors { get; set; }
    }
}
