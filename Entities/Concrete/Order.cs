using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderID { get; set; }
        public int EmployeeId { get; set; }
        public int TableId { get; set; }
        public DateTime? OrderDate { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual List<OrderDetail> OrderDetails{ get; set; }

    }
}