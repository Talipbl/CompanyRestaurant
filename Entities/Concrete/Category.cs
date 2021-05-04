using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }


        public virtual List<Product> Products { get; set; }
        public virtual List<Recipe> Recipes { get; set; }

    }
}
