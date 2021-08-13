using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DataTransferObject
{
    public class OrderDetailsDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public float Quantity { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeId { get; set; }
        public int TableId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
    }
}
