using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<ProductsDTO>> GetProducts();
        IDataResult<List<Product>> GetProductsByCategory(int categoryId);
        IDataResult<List<RecipeProductDTO>> GetProductsByRecipe(int recipeId);
        IDataResult<Product> GetProduct(int productId);
        IResult Add(Product product);
        IResult Delete(int id);
        IResult Update(Product product);
    }
}
