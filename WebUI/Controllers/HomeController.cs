using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    //[Authorize]
    public class HomeController : Controller
    {
        string _url = "https://localhost:44396/";
        ProductProcessor _productProcessor;
        OrderProcessor _orderProcessor;
        TableProcessor _tableProcessor;
        PersonProcessor _personProcessor;

        public HomeController(IHttpContextAccessor contextAccessor)
        {
            _productProcessor = new ProductProcessor(_url, Token.GetToken(contextAccessor));
            _tableProcessor = new TableProcessor(_url, Token.GetToken(contextAccessor));
            _orderProcessor = new OrderProcessor(_url, Token.GetToken(contextAccessor));
            _personProcessor = new PersonProcessor(_url, Token.GetToken(contextAccessor));

        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            HomepageDTO homePage = new HomepageDTO()
            {
                TableStatus = await _tableProcessor.GetTableStatusAsync(),
                OrderAmounts = await _orderProcessor.GetOrdersAmountAsync(),
                LastOrders = await _orderProcessor.GetLastOrdersAsync(),
                Person = HttpContext.Session.GetObject<EmployeeSessionDTO>("user").Person
            };
            return View(homePage);

        }
    }
}
