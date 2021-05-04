using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class StockUnit:IEntity
    {
        public int UnitID { get; set; }
        public string UnitType { get; set; }


        public virtual List<Product> Products { get; set; }

    }
}
