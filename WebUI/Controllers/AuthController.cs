using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Methods.ApiProcessors;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        string _url = "https://localhost:44396/";
        AuthProcessor authProcessor;
        public AuthController()
        {
            authProcessor = new AuthProcessor(_url);
        }
        [HttpGet]
        public ActionResult Login()
        {
            EmployeeLoginDTO loginDTO = new EmployeeLoginDTO();
            return View(loginDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Login(EmployeeLoginDTO employeeLoginDTO)
        {
            var result = await authProcessor.LoginAsync(employeeLoginDTO);
            //HttpContext.Session  Session yapısını kur. Extension oluşturulacak!!!
            return View();
        }
    }
}
