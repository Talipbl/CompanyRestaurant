using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.ApiControllers;
using WebUI.ApiControllers.ApiProcessors;
using WebUI.Methods;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        string _url = ApiClientHelper.ApiConnectUrl;
        ProductProcessor _productProcessor;
        CategoryProcessor _categoryProcessor;
        public ProductController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = TokenHelper.GetToken(contextAccessor);
            _productProcessor = new ProductProcessor(_url, accessToken);
            _categoryProcessor = new CategoryProcessor(_url, accessToken);
        }
        private ProductManipulationViewModel GetManipulationModel(Product product, List<string> errors = null)
        {
            ProductManipulationViewModel model = new ProductManipulationViewModel
            {
                Product = product,
                Categories = _categoryProcessor.GetCategoriesAsync().Result.Entity,
                Errors = errors
            };
            return model;
        }
        private void VerifyTransaction(HttpResponseMessage responseMessage, string actionName, string successMessage)
        {
            //Initialize
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
            return View(GetManipulationModel(new Product()));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _productProcessor.AddProductAsync(product);
            if (result.ResponseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = result.Entity.Message;
                return RedirectToAction(nameof(ListProducts));
            }
            ModelState.AddModelError("", "");
            return View(GetManipulationModel(product, result.Entity.Errors));
        }
        [HttpGet]
        public async Task<IActionResult> DiscontinuedProduct(int id, bool statu)
        {
            var firstData = await _productProcessor.GetProductAsync(id);
            firstData.Entity.Discontinued = statu == true ? false : true;
            var result = await _productProcessor.UpdateProductAsync(firstData.Entity);
            if (!result.ResponseMessage.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = result.Entity.Message;
            }
            TempData["SuccessMessage"] = result.Entity.Message;
            ModelState.AddModelError("", "");
            return RedirectToAction(nameof(ListProducts));
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var result = await _productProcessor.GetProductAsync(id);
            if (!result.ResponseMessage.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = result.ResponseMessage.RequestMessage;
                ModelState.AddModelError("", "");
                return RedirectToAction(nameof(ListProducts));
            }
            ProductManipulationViewModel model = new ProductManipulationViewModel
            {
                Categories = _categoryProcessor.GetCategoriesAsync().Result.Entity,
                Product = result.Entity
            };
            return View(model);
        }

    }
}
