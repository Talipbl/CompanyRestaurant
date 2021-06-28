using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.ApiControllers.ApiProcessors;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        string _url = "https://localhost:44396/";
        PersonProcessor _personProcessor;

        public PersonController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = TokenHelper.GetToken(contextAccessor);
            _personProcessor = new PersonProcessor(_url, accessToken);
        }
        [HttpGet]
        public async Task<IActionResult> GetPerson(int personId)
        {
            var result = await _personProcessor.GetPerson(personId);
            if (result != null)
            {
                return View(result);
            }
            return BadRequest();
        }
    }
}
