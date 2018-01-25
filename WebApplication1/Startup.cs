using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public string DevDbString { get; set; }
        public string ProdDbString { get; set; }
        public string EnvironmentIn { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            DevDbString = Configuration["DevDb"];
            ProdDbString = Environment.GetEnvironmentVariable("ProdDbString");
            EnvironmentIn = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");



            switch(EnvironmentIn)
            {
                case "Development":
                    services.AddDbContext<IdentityContext>(options =>
                        options.UseSqlServer(DevDbString));
                    services.AddDbContext<ThingContext>(options =>
                        options.UseSqlServer(DevDbString));
                    break;
                case "Production":
                    services.AddDbContext<IdentityContext>(options =>
                        options.UseSqlServer(ProdDbString));
                    services.AddDbContext<ThingContext>(options =>
                        options.UseSqlServer(ProdDbString));
                    break;
                default:
                    break;
            }


            services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender,EmailSender>();

            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
