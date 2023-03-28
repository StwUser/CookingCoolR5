using CookingCoolR5.Data;
using CookingCoolR5.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingCoolR5.Helpers.Token
{
    public class TokenHelper
    {
        AuthModel AuthModel { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }

        public TokenHelper(AuthModel authModel, string userName, string userRole)
        {
            AuthModel = authModel;
            UserName = userName;
            UserRole = userRole;
        }
        public string GetToken() 
        {
            var identity = GetIdentity(UserName, UserRole);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(issuer: AuthModel.Issuer,
                                           audience: AuthModel.Consumer,
                                           notBefore: now,
                                           claims: identity.Claims,
                                           expires: now.Add(TimeSpan.FromMinutes(AuthModel.LifeTime)),
                                           signingCredentials: new SigningCredentials(AuthModel.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private ClaimsIdentity GetIdentity(string userName, string userRole)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole),
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
