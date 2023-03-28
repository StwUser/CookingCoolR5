using CookingCoolR5.Data;
using CookingCoolR5.Data.Interfaces;
using CookingCoolR5.Helpers.Email;
using CookingCoolR5.Helpers.Token;
using CookingCoolR5.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingCoolR5
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }
        public AuthModel AuthModel { get; set; } = new AuthModel();
        public EmailConfigModel EmailConfigModel { get; set; } = new EmailConfigModel();

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            if (env.IsDevelopment())
            {
                ConnectionString = Configuration.GetConnectionString("Develop");
            }
            else
            {
                ConnectionString = Configuration["ConnectionString"];
            }
            Configuration.GetSection("Email").Bind(EmailConfigModel);
            Configuration.GetSection("Token").Bind(AuthModel);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication()
                .AddJwtBearer(op =>
                {
                    op.RequireHttpsMetadata = false;
                    op.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Validate publisher
                        ValidateIssuer = true,
                        //Publisher
                        ValidIssuer = AuthModel.Issuer,
                        //Validate cunsomer
                        ValidateAudience = true,
                        //Setup cunsomer
                        ValidAudience = AuthModel.Consumer,
                        //Life time
                        ValidateLifetime = true,
                        //Setup security key
                        IssuerSigningKey = AuthModel.GetSymmetricSecurityKey(),
                        //Validation security key
                        ValidateIssuerSigningKey = true,
                    };
                });

            //Configure DBContext with SQL
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

            services.AddScoped<ITokenService, TokenService>(serviceProvider => new TokenService(AuthModel));
            services.AddScoped<IEmailService, EmailService>(serviceProvider => new EmailService(EmailConfigModel));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
