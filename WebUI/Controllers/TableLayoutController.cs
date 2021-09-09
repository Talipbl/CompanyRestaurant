using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ApiControllers;
using WebUI.ApiControllers.ApiProcessors;
using WebUI.Methods;

namespace WebUI.Controllers
{
    public class TableLayoutController : Controller
    {
        string _url = ApiClientHelper.ApiConnectUrl;
        TableLayoutProcessor _tableLayoutProcessor;

        public TableLayoutController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = TokenHelper.GetToken(contextAccessor);
            _tableLayoutProcessor = new TableLayoutProcessor(_url, accessToken);
        }

        [HttpPost]
        public async Task<ActionResult> AddLayout(IFormFile file)
        {
            var result = await _tableLayoutProcessor.AddLayoutAsync(file);
            if (result.ResponseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = result.Entity;
            }
            TempData["ErrorMessage"] = result.Entity;
            ModelState.AddModelError("", "");
            return RedirectToAction("TableLayout", "Table");
        }
    }
}
