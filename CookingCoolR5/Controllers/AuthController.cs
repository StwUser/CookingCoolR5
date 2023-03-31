using CookingCoolR5.Data;
using CookingCoolR5.Data.Constants;
using CookingCoolR5.Data.Interfaces;
using CookingCoolR5.Data.Models;
using CookingCoolR5.Data.ViewModels;
using CookingCoolR5.Helpers.Email;
using CookingCoolR5.Helpers.RandomStringCreator;
using CookingCoolR5.Helpers.Token;
using CookingCoolR5.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookingCoolR5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext Context;
        private readonly ITokenService TokenService;
        private readonly IEmailService EmailService;
        private readonly IWebHostEnvironment AppHostEnvironment;

        public AuthController(AppDbContext context, ITokenService tokenService, IEmailService emailService, IWebHostEnvironment appEnvironment)
        {
            Context = context;
            TokenService = tokenService;
            EmailService = emailService;
            AppHostEnvironment = appEnvironment;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser([FromForm]UserRegistrationVm userRegistration)
        { 
            var someCredsExists = await Context.Users.AnyAsync(u => u.Name == userRegistration.Name || u.Login == userRegistration.Login || u.Password == userRegistration.Password || u.Email == userRegistration.Email);
            if(someCredsExists) 
            {
                return BadRequest("Some registration information already exists.");
            }

            var code = RandomHelper.GetRandomString(32);
            var callbackUrl = Url.Action("UserVerification", "Auth", new { VerificationCode = code }, protocol: HttpContext.Request.Scheme);
            var emailBody = $"Confirm your registration by clicking on the link: <a href='{callbackUrl}'>link</a>";
            await EmailService.SendEmailAsync(userRegistration.Email, "Confirm your account", emailBody);

            var newUser = new User { Name = userRegistration.Name, Login = userRegistration.Login, Password = userRegistration.Password, Email = userRegistration.Email, Role = nameof(Roles.User), IsEmailConfirmed = false };
            await Context.Users.AddAsync(newUser);
            await Context.SaveChangesAsync();

            await Context.EmailVerifications.AddAsync(new EmailVerification { UserId = newUser.Id, VerificationCode = code });
            await Context.SaveChangesAsync();

            return Ok("Email with registration code sended.");
        }

        [HttpGet("verification")]
        public async Task<IActionResult> UserVerification([FromQuery] string verificationCode)
        {
            var newUser = await Context.EmailVerifications.FirstOrDefaultAsync(v => v.VerificationCode == verificationCode);

            if(newUser == null)
            {
                return BadRequest("Sorry user don't exists.");
            }

            var existsUser = await Context.Users.FirstOrDefaultAsync(u => u.Id == newUser.UserId);
            existsUser.IsEmailConfirmed = true;
            Context.EmailVerifications.Remove(newUser);
            await Context.SaveChangesAsync();

            return Ok("Email was confirmed.");
        }

        [HttpPost("getToken")]
        public async Task<IActionResult> Login([FromForm]string username, [FromForm]string password)
        {
            var path = AppHostEnvironment.ContentRootPath + "/logs/logs.txt";
            var path2 = AppHostEnvironment.WebRootPath + "/logs/" + "logs2.txt";
            try
            {
                var user = await Context.Users.FirstOrDefaultAsync(x => x.Login == username && x.Password == password);
                if (user == null)
                {
                    return BadRequest(new { errorText = "Invalid username or password." });
                }

                var encodedJwt = TokenService.GetEncodedJwt(user.Name, user.Role);
                return Ok(new { AccessToken = encodedJwt, UserТame = user.Name, UserId = user.Id, UserRole = user.Role });
            }
            catch (Exception ex) 
            {
                using StreamWriter file = new(path2, append: true);
                await file.WriteLineAsync($"Time: {DateTime.Now}{Environment.NewLine}CanConnect: {Context.Database.CanConnect()} ConnectionString: {Context.Database.GetConnectionString()}{Environment.NewLine}{Environment.NewLine} {Context.Database.CanConnect}{Environment.NewLine}Message: {ex.Message}{Environment.NewLine}Source: {ex.Source}{Environment.NewLine}InnerExeception {ex.InnerException}{Environment.NewLine}BaseException {ex.GetBaseException()}");
            }

            return BadRequest("Something gone wrong.");
        }

    }
}
