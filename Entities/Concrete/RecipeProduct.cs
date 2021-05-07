using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RecipeProduct : IEntity
    {
        public int RecipeID { get; set; }
        public int ProductID { get; set; }
        public float? Quantity { get; set; }


        public virtual Product Product { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
