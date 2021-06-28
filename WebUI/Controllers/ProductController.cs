using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ApiControllers.ApiProcessors;
using WebUI.Methods;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        string _url = "https://localhost:44396/";
        ProductProcessor _productProcessor;
        CategoryProcessor _categoryProcessor;
        public ProductController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = TokenHelper.GetToken(contextAccessor);
            _productProcessor = new ProductProcessor(_url, accessToken);
            _categoryProcessor = new CategoryProcessor(_url, accessToken);

        }
        [HttpGet]
        public async Task<IActionResult> ListProducts()
        {
            ListProductsViewModel model = new ListProductsViewModel
            {
                Products = await _productProcessor.GetProductsAsync()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ProductManipulationViewModel model = new ProductManipulationViewModel
            {
                Product = new Product(),
                Categories = _categoryProcessor.GetCategoriesAsync().Result.Entity
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _productProcessor.AddProductAsync(product);
            if (result.ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ListProducts));
            }
            return View();
        }
    }
}
