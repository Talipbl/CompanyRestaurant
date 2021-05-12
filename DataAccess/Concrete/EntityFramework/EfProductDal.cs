using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, CompanyContext>, IProductDal
    {
        private static IQueryable<RecipeProductDTO> GetProductsByRecipeIdWithJoin(CompanyContext context, int recipeId)
        {
            return from rp in context.RecipesProducts
                   join p in context.Products on rp.ProductID equals p.ProductID
                   join r in context.Recipes on rp.RecipeID equals r.RecipeID
                   where rp.RecipeID == recipeId

                   select new RecipeProductDTO
                   {
                       ProductID = p.ProductID,
                       CategoryId = p.Category.CategoryID,
                       ProductName = p.ProductName,
                       UnitPrice = p.UnitPrice,
                       Quantity = rp.Quantity,
                       //Unit = p.StockUnit.UnitType,
                       UnitsInRestaurantStock = p.UnitsInRestaurantStock,
                       UnitsInWarhouseStock = p.UnitsInWarhouseStock
                   };
        }

        public List<RecipeProductDTO> GetProductsByRecipe(int recipeId)
        {
            using (CompanyContext context = new CompanyContext())
            {
                IQueryable<RecipeProductDTO> result = GetProductsByRecipeIdWithJoin(context, recipeId);
                return result.ToList();
            }
        }
    }
}
