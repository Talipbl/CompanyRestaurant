using Business.Concrete.Managers;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GetProducts();
            GetCategories();
            GetStockUnits();

        }

        private static void GetStockUnits()
        {
            StockUnitManager stockUnitManager = new StockUnitManager(new EfStockUnitDal());
            foreach (var unit in stockUnitManager.GetStockUnits().Data)
            {
                Console.WriteLine(unit.UnitType);
            }
        }

        private static void GetCategories()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetCategories().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void GetProducts()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProducts().Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
