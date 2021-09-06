using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.ApiControllers.ApiProcessors;
using WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using WebUI.ApiControllers;

namespace WebUI.Controllers
{
    [Authorize]
    public class TableController : Controller
    {
        string _url = ApiClientHelper.ApiConnectUrl;
        TableProcessor _tableProcessor;

        public TableController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = TokenHelper.GetToken(contextAccessor);
            _tableProcessor = new TableProcessor(_url, accessToken);
        }

        [HttpGet]
        public async Task<ActionResult> TableManager()
        {
            var result = await _tableProcessor.GetTables();
            if (result != null)
            {
                TableViewModel model = new TableViewModel()
                {
                    Tables = result,
                };
                return View(model);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> GetTables()
        {
            var result = await _tableProcessor.GetTables();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult AddTable()
        {
            Table model = new Table();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddTable(Table table)
        {
            table.Status = true;
            await _tableProcessor.AddTableAsync(table);
            return RedirectToAction(nameof(TableManager));
        }

        [HttpGet]
        public async Task<ActionResult> DeleteTable(int id)
        {
            var result = await _tableProcessor.DeleteTableAsync(id);
            if (!result.ResponseMessage.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = result.ResponseMessage.ReasonPhrase;
            }
            else 
                TempData["SuccessMessage"] = result.Entity;
            ModelState.AddModelError("", "");
            return RedirectToAction(nameof(TableManager));
        }
    }
}
