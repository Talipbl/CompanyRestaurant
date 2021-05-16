using Autofac;
using Business.Abstract;
using Business.Concrete.Managers;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IOC;
using DataAccess.Concrete.EntityFramework;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IOC CONTAINER CONFIGURATION
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacBusinessModule>();
            var container = builder.Build();

            IProductService productService = container.Resolve<IProductService>();
            ICategoryService categoryService = container.Resolve<ICategoryService>();

            //IProductService productService = ServiceTool.ServiceProvider.GetService<IProductService>();

            GetProducts(productService);
            //GetCategories(categoryService);
            //GetStockUnits();

        }

        //private static void GetStockUnits()
        //{
        //    StockUnitManager stockUnitManager = new StockUnitManager(new EfStockUnitDal());
        //    foreach (var unit in stockUnitManager.GetStockUnits().Data)
        //    {
        //        Console.WriteLine(unit.UnitType);
        //    }
        //}

        private static void GetCategories(ICategoryService categoryService)
        {
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryService.GetCategories().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void GetProducts(IProductService productService)
        {
            //ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productService.GetProducts().Data)
            {
                Console.WriteLine($"{product.ProductName} - {product.Category.CategoryName} - {product.UnitPrice.ToString("C2")} - {product.UnitsInRestaurantStock} - {product.UnitsInWarhouseStock}");
            }
        }
    }
}
