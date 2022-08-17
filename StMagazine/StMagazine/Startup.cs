using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StMagazine.Models;
using StMagazine.Interfaces;
using StMagazine.SQLRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace StMagazine
{
    public class Startup
    {
        private IConfigurationRoot _confstring;
        public Startup(IHostEnvironment ihv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(ihv.ContentRootPath).AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // добавляем контекст ApplicationContext в качестве сервиса в приложение
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddScoped<IStudentRepository, SQLStudentRepository>();
            services.AddScoped<ITeacherRepository, SQLTeacherRepository>();
            services.AddScoped<IGroupRepository, SQLGroupRepository>();
            services.AddScoped<IItemRepository, SQLItemRepository>();
            services.AddScoped<ICoursRepository, SQLCoursRepository>();
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opts =>
            {
                opts.Cookie.Name = "MyCompanyAuth";
                opts.Cookie.HttpOnly = true;
                opts.LoginPath = "/account/login";
                opts.AccessDeniedPath = "/account/accessdenied";
                opts.SlidingExpiration = true;
            });
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
               /* endpoints.MapControllerRoute(
                    name: "students",
                    pattern: "Students/{action=Index}/{id?}",
                    defaults: new { controller = "Student" });
                endpoints.MapControllerRoute(
                    name: "groups",
                    pattern: "Groups/{action=Index}/{id?}",
                    defaults: new { controller = "Group" });
                endpoints.MapControllerRoute(
                  name: "items",
                  pattern: "Items/{action=Index}/{id?}",
                  defaults: new { controller = "Item" });*/
            });
           
                
        }
    }
}
