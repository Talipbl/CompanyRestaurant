using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.Methods.ApiProcessors;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        string _url = "https://localhost:44396/";
        ProductProcessor _productProcessor;
        OrderProcessor _orderProcessor;
        TableProcessor _tableProcessor;
        public HomeController()
        {
            _productProcessor = new ProductProcessor(_url);
            _tableProcessor = new TableProcessor(_url);
            _orderProcessor = new OrderProcessor(_url);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            HomepageDTO homePage = new HomepageDTO()
            {
                TableStatus = await _tableProcessor.GetTableStatusAsync(),
                OrderAmounts = await _orderProcessor.GetOrdersAmountAsync(),
                LastOrders = await _orderProcessor.GetLastOrders()
            };
            return View(homePage);
        }
    }
}
