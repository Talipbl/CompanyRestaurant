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
                       //UnitType = p.StockUnit.UnitType,
                       UnitsInRestaurantStock = p.UnitsInRestaurantStock,
                       UnitsInWarhouseStock = p.UnitsInWarhouseStock
                   };
        }

        private static IQueryable<ProductsDTO> GetProductsWithJoin(CompanyContext context)
        {
            return from p in context.Products
                   join c in context.Categories on p.CategoryId equals c.CategoryID

                   select new ProductsDTO
                   {
                       ProductID = p.ProductID,
                       CategoryId = p.Category.CategoryID,
                       CategoryName = p.Category.CategoryName,
                       ProductName = p.ProductName,
                       UnitPrice = p.UnitPrice,
                       UnitsInRestaurantStock = p.UnitsInRestaurantStock,
                       UnitsInWarhouseStock = p.UnitsInWarhouseStock,
                       Discontinued = p.Discontinued
                   };
        }

        public List<RecipeProductDTO> GetProductsByRecipe(int recipeId)
        {
            using (CompanyContext db = new CompanyContext())
            {
                IQueryable<RecipeProductDTO> result = GetProductsByRecipeIdWithJoin(db, recipeId);
                return result.ToList();
            }
        }

        public List<ProductsDTO> GetProductsWithCategory()
        {
            using (CompanyContext db = new CompanyContext())
            {
                IQueryable<ProductsDTO> result = GetProductsWithJoin(db);
                return result.ToList();
                //return db.Set<Product>().Include(x => x.Category).ToList();
            }
        }
    }
}
