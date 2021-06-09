using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.Methods.ApiProcessors;

namespace WebUI.Controllers
{
    public class TablesController : Controller
    {
        string _url = "https://localhost:44396/";
        TableProcessor _tableProcessor;

        public TablesController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = Token.GetToken(contextAccessor);
            _tableProcessor = new TableProcessor(_url, accessToken);
        }

        [HttpGet]
        public async Task<ActionResult> GetTables()
        {
            var result = await _tableProcessor.GetTables();
            if (result!=null)
            {
                return View(result);
            }
            return BadRequest();
        }
    }
}
