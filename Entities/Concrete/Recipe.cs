using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Recipe : IEntity
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public int CategoryId { get; set; }


        public virtual Category Category { get; set; }
        public virtual List<RecipeProduct> RecipesProducts { get; set; }
    }
}
