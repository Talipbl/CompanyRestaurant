using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Models.DataTransferObjects;

namespace WebUI.Methods
{
    [Authorize]
    public static class TokenHelper
    {
        private static IHttpContextAccessor TokenContext { get; set; }
        public static string GetToken(IHttpContextAccessor context)
        {
            TokenContext = context;
            string token = null;
            if (TokenContext.HttpContext.Session.GetObject<EmployeeSessionDTO>("user") != null)
            {
                token = TokenContext.HttpContext.Session.GetObject<EmployeeSessionDTO>("user").Entity.AccessToken.Token;
                return token;
            }
            return null;
        }
    }
}
