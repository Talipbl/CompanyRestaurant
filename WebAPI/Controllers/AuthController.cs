using Business.Abstract;
using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthorizeService _auhthorizeService;
        public AuthController(IAuthorizeService authorizeService)
        {
            _auhthorizeService = authorizeService;
        }

        [HttpPost("register")]
        public IActionResult Register(EmployeeRegisterDTO employeeRegisterDTO)
        {
            var userExists = _auhthorizeService.UserExistsWithPersonelId(employeeRegisterDTO.Identity);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = _auhthorizeService.Register(employeeRegisterDTO);
            var result = _auhthorizeService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public IActionResult Login(EmployeeLoginDTO employeeLoginDTO)
        {
            var userLogin = _auhthorizeService.Login(employeeLoginDTO);
            if (userLogin.Success)
            {
                var userAccessToken = _auhthorizeService.CreateAccessToken(userLogin.Data);
                if (userAccessToken.Success)
                {
                    return Ok(userAccessToken);
                }
                return BadRequest(userAccessToken.Message);
            }
            return BadRequest(userLogin.Message);
        }
    }
}
