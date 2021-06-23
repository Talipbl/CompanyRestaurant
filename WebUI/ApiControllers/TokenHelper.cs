using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Methods
{
    public static class TokenHelper
    {
        public static IHttpContextAccessor TokenContext { get; set; }
        public static string GetToken(IHttpContextAccessor context)
        {
            TokenContext = context;
            string token = null;
            if (TokenContext.HttpContext.Session.GetObject<ResponseDTO<EmployeeSessionDTO>>("user") != null)
            {
                token = TokenContext.HttpContext.Session.GetObject<ResponseDTO<EmployeeSessionDTO>>("user").Entity.AccessToken.Token;
                return token;
            }
            throw new Exception();
        }
    }
}
