using CookingCoolR5.Data;
using CookingCoolR5.Data.Constants;
using CookingCoolR5.Data.Interfaces;
using CookingCoolR5.Data.Models;
using CookingCoolR5.Data.ViewModels;
using CookingCoolR5.Helpers.Email;
using CookingCoolR5.Helpers.LogWriter;
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
        private readonly string LogsPath;

        public AuthController(AppDbContext context, ITokenService tokenService, IEmailService emailService, IWebHostEnvironment appEnvironment)
        {
            Context = context;
            TokenService = tokenService;
            EmailService = emailService;
            AppHostEnvironment = appEnvironment;
            LogsPath = appEnvironment.WebRootPath;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser([FromBody] UserRegistrationVm userRegistration)
        {
            var someCredsExists = await Context.Users.AnyAsync(u => u.Name == userRegistration.Name || u.Login == userRegistration.UserName || u.Password == userRegistration.Password || u.Email == userRegistration.Email);
            if (someCredsExists)
            {
                return BadRequest("Some registration information already exists.");
            }
            if (string.IsNullOrEmpty(userRegistration.Email) || string.IsNullOrEmpty(userRegistration.UserName) || string.IsNullOrEmpty(userRegistration.Name) || string.IsNullOrEmpty(userRegistration.Password))
            {
                return BadRequest("Some registration information is wrong.");
            }

            var code = RandomHelper.GetRandomString(32);
            var callbackUrl = Url.Action("UserVerification", "Auth", new { VerificationCode = code }, protocol: HttpContext.Request.Scheme);
            var emailBody = $"Confirm your registration by clicking on the link: <a href='{callbackUrl}'>link</a>";

            try
            {
                await EmailService.SendEmailAsync(userRegistration.Email, "Confirm your account", emailBody, logsPat);
            }
            catch (Exception ex)
            {
                await LogWriter.WrireAsync(LogsPath, ex);
            }

            var newUser = new User { Name = userRegistration.Name, Login = userRegistration.UserName, Password = userRegistration.Password, Email = userRegistration.Email, Role = nameof(Roles.User), IsEmailConfirmed = false };
            await Context.Users.AddAsync(newUser);
            await Context.SaveChangesAsync();

            await Context.EmailVerifications.AddAsync(new EmailVerification { UserId = newUser.Id, VerificationCode = code });
            await Context.SaveChangesAsync();

            return Ok("Email with registration code sended.");
        }

        [HttpGet("verification")]
        public async Task<ContentResult> UserVerification([FromQuery] string verificationCode)
        {
            var newUser = await Context.EmailVerifications.FirstOrDefaultAsync(v => v.VerificationCode == verificationCode);

            if (newUser == null)
            {
                var sorry = "<div>Sorry User don't exists.</div>";
                return base.Content(sorry, "text/html");
            }

            var existsUser = await Context.Users.FirstOrDefaultAsync(u => u.Id == newUser.UserId);
            existsUser.IsEmailConfirmed = true;
            Context.EmailVerifications.Remove(newUser);
            await Context.SaveChangesAsync();

            var html = "<div>Your account has been verified.</div>";
            return base.Content(html, "text/html");
        }

        [HttpPost("getToken")]
        public async Task<IActionResult> Login([FromBody] AuthModel creds)
        {
            var username = creds.UserName;
            var password = creds.Password;

            try
            {
                var user = await Context.Users.FirstOrDefaultAsync(x => x.Login == username && x.Password == password);
                if (user == null)
                {
                    return BadRequest(new { errorText = "Invalid username or password." });
                }

                var encodedJwt = TokenService.GetEncodedJwt(user.Name, user.Role);
                return Ok(new { AccessToken = encodedJwt, UserName = user.Name, UserId = user.Id, UserRole = user.Role });
            }
            catch (Exception ex) 
            {
                await LogWriter.WrireAsync(LogsPath, ex);
            }

            return BadRequest("Something gone wrong.");
        }

    }

    public class AuthModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
