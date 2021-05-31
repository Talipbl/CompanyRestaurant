using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DataTransferObject
{
    public class TablesStatusDTO
    {
        public TablesStatusDTO()
        {
            trueValue = 0;
            falseValue = 0;
            chairCount = 0;
        }
        public int trueValue { get; set; }
        public int falseValue { get; set; }
        public int chairCount { get; set; }
    }
}
