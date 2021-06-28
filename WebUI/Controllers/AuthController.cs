using Business.BusinessAspects.Autofac;
using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.ApiControllers.ApiProcessors;
using Core.Utilities.Extensions;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        string _url = "https://localhost:44396/";
        AuthProcessor _authProcessor;
        IHttpContextAccessor _contextAccessor;
        public AuthController(IHttpContextAccessor contextAccessor)
        {
            _authProcessor = new AuthProcessor(_url);
            _contextAccessor = contextAccessor;
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
            var result = await _authProcessor.LoginAsync(employeeLoginDTO);

            List<Claim> claims = new List<Claim>();
            claims.AddNameIdentifier(result.Entity.Employee.EmployeeID.ToString());
            claims.AddName($"{result.Entity.Person.FirstName} {result.Entity.Person.LastName}");
            ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            HttpContext.Session.SetObject("user", result.Entity);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login", "Auth");
        }
    }
}
