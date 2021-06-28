using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DataTransferObject
{
    public class ProductsDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public float? UnitsInRestaurantStock { get; set; }
        public float? UnitsInWarhouseStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
