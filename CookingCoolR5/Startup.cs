using CookingCoolR5.Data;
using CookingCoolR5.Data.AunthModel;
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

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            if (env.IsDevelopment())
            {
                ConnectionString = Configuration.GetConnectionString("Develop");
            }
            else
            {
                ConnectionString = Configuration.GetSection("ConnectionString").Value;
            }
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
                        ValidIssuer = AunthModel.Issuer,
                        //Validate cunsomer
                        ValidateAudience = true,
                        //Setup cunsomer
                        ValidAudience = AunthModel.Consumer,
                        //Life time
                        ValidateLifetime = true,
                        //Setup security key
                        IssuerSigningKey = AunthModel.GetSymmetricSecurityKey(),
                        //Validation security key
                        ValidateIssuerSigningKey = true,
                    };
                });

            //Configure DBContext with SQL
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
