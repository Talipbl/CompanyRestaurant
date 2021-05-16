using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Security.Encrypiton;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Core.Entities;
using System.Security.Claims;
using Core.Utilities.Extensions;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//Read API appsettings
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)//Read API appsettings when use injection
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        public AccessToken CreateToken(Person person, List<OperationClaim> operaitonClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, person, signingCredentials, operaitonClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Person person,
            SigningCredentials signingCredentials, List<OperationClaim> operaitonClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(person, operaitonClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(Person person, List<OperationClaim> operaitonClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(person.PersonID.ToString());
            claims.AddName($"{person.FirstName} {person.LastName}");
            claims.AddRoles(operaitonClaims.Select(c => c.ClaimName).ToArray());

            return claims;
        }
    }
}
