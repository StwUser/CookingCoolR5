using CookingCoolR5.Data;
using CookingCoolR5.Data.AunthModel;
using CookingCoolR5.Data.Models;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingCoolR5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AunthController : ControllerBase
    {
        private readonly AppDbContext Context;
        public int UserId { get; set; } = 0;
        public string UserRole { get; set; }

        public string UserName { get; set; }

        public AunthController(AppDbContext context)
        {
            Context = context;
        }

        [HttpGet("hello")]
        public async Task<IActionResult> Hello() => Ok(new { Message = "Hello Loser" });

        [HttpPost("getToken")]
        public async Task<IActionResult> Login([FromForm]string username, [FromForm]string password)
        {
            var identity = await GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(issuer: AunthModel.Issuer,
                                           audience: AunthModel.Consumer,
                                           notBefore: now,
                                           claims: identity.Claims,
                                           expires: now.Add(TimeSpan.FromMinutes(AunthModel.LifeTime)),
                                           signingCredentials: new SigningCredentials(AunthModel.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Ok(new { AccessToken = encodedJwt, Username = UserName, UserId = UserId, UserRole = UserRole });
        }

        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Login == username && x.Password == password);
            if(user == null)
            {
                return null;
            }

            UserId = user.Id;
            UserRole = user.Role;
            UserName = user.Name;

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }


    }
}
