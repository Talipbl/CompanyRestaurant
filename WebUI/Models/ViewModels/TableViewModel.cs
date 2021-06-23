using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Models.ViewModels
{
    public class TableViewModel
    {
        public ResponseDTO<List<Table>> Tables { get; set; }
    }
}
