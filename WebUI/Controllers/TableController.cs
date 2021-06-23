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

namespace WebUI.Controllers
{
    public class TableController : Controller
    {
        string _url = "https://localhost:44396/";
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
            if (result!=null)
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
    }
}
