using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DataTransferObject
{
    public class RecipeProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public float? UnitsInRestaurantStock { get; set; }
        public float? UnitsInWarhouseStock { get; set; }
        public float? Quantity { get; set; }
        public string Unit { get; set; }
    }
}
