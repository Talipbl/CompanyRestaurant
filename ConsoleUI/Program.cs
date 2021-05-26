using Autofac;
using Business.Abstract;
using Business.Concrete.Managers;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IOC;
using DataAccess.Concrete.EntityFramework;
using System;
using Microsoft.Extensions.DependencyInjection;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

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

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ServiceTool.ContainerServiceCreate(serviceCollection);

            Product product = new Product()
            {
                ProductName = "Şakşuka",
                CategoryId = 3,
                UnitPrice = 25,
                UnitsInRestaurantStock = 3,
                UnitsInWarhouseStock = 10,
                Discontinued = false
            };

            productService.Add(product);

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
                Console.WriteLine($"{product.ProductName} - {product.UnitPrice.ToString("C2")} - {product.UnitsInRestaurantStock} - {product.UnitsInWarhouseStock}");
            }
        }
    }
}
