using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Methods
{
    public static class Token
    {
        public static IHttpContextAccessor TokenContext { get; set; }
        public static string GetToken(IHttpContextAccessor context)
        {
            TokenContext = context;
            string token = null;
            if (TokenContext.HttpContext.Session.GetObject<EmployeeSessionDTO>("user") != null)
            {
                token = TokenContext.HttpContext.Session.GetObject<EmployeeSessionDTO>("user").AccessToken.Token;
                return token;
            }
            throw new Exception();
        }
    }
}
