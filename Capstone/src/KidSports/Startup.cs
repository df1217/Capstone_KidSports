using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using KidSports.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KidSports.Models;

namespace KidSports
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json")
            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
            //.AddEnvironmentVariables();
            .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                         Configuration["Data:KidSportsDB:ConnectionString"]));

            //services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
            //    Configuration["Data:KidSportsIdentity:ConnectionString"]));

            services.AddIdentity<User, IdentityRole>(opts =>
            { opts.Cookies.ApplicationCookie.LoginPath = "/Account/Login"; })
                 .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IApplicationRepo, ApplicationRepository>();
            services.AddTransient<IUserRepo, UserRepository>();
            services.AddTransient<IStateRepo, StateRepository>();
            services.AddTransient<IAreaRepo, AreaRepository>();
            services.AddTransient<ISchoolRepo, SchoolRepository>();
            services.AddTransient<ISportRepo, SportRepository>();
            services.AddTransient<IGradeRepo, GradeRepository>();
            services.AddTransient<IExpRepo, ExperienceRepository>();
            services.AddTransient<IAppStatusRepo, AppStatusRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}");
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
