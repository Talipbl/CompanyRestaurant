using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encrypiton
{
    public class SigningCredentialsHelper
    {
        //For Json Web Token
        //Credential = login info
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //The security key and security algorithm to be used for the json web token
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
