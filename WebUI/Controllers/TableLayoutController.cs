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
            //string directory = Environment.CurrentDirectory + "\\wwwroot";
            string directory = "http://sixxen.xyz/upload_image/upload.php";
            var result = await _tableLayoutProcessor.UploadLayoutAsync(file,directory);
            if (result.ResponseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = result.Entity;
            }
            else
                TempData["ErrorMessage"] = result.Entity;
            ModelState.AddModelError("", "");
            return RedirectToAction("TableLayout", "Table");
        }
    }
}
