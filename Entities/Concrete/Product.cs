using Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public float? UnitsInRestaurantStock { get; set; }
        public float? UnitsInWarhouseStock { get; set; }
        //public int UnitId { get; set; }
        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }
        //public virtual StockUnit StockUnit { get; set; }
        public virtual List<RecipeProduct> RecipesProducts { get; set; }

    }
}
