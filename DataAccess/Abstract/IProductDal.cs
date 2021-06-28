using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //Object specific actions

        List<RecipeProductDTO> GetProductsByRecipe(int recipeId);

        List<ProductsDTO> GetProductsWithCategory();
    }
}
