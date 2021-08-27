using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week5.Test.Restaurant.Core.BusinessLayer;
using Week5.Test.Restaurant.Core.EF;
using Week5.Test.Restaurant.Core.EF.Repositories;
using Week5.Test.Restaurant.Core.Repositories;

namespace Week5.Test.Restaurant.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBusinessLayer, MainBusinessLayer>();
            services.AddScoped<IDishRepository, EFDishRepository>();
            services.AddScoped<IUserRepository, EFUserRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserOwner",
                    policy => policy.RequireRole("Owner"));
            }
            );

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Home/Login");
                    options.AccessDeniedPath = new PathString("/Home/Forbidden");
                });

            services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("RestaurantDB"));
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
