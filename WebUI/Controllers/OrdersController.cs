using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class OrdersController : Controller
    {
        string _url = "https://localhost:44396/";
        public IActionResult Index()
        {

            return View();
        }
    }
}
