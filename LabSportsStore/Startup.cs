using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSportsStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LabSportsStore
{
    public class Startup
    {
        // F i e l d s  &  P r o p e r t i e s

        private IConfiguration configuration { get; }

        // C o n s t r u c t o r s

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // M e t h o d s

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer
                    (configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductRepository,EfProductRepository>();//when you ask for an interface give me the concrete class
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting(); 
            app.UseSession();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: null,
                   pattern: "{controller=Product}/{action=Index}/{category}/Page{productPage:int}");

                endpoints.MapControllerRoute(
                   name: null,
                   pattern: "{controller=Product}/{action=Index}/Page{productPage:int}");

                endpoints.MapControllerRoute(
                   name: null,
                   pattern: "{controller=Product}/{action=Index}/{category:alpha?}"); //alpha is a search word

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Product}/{action=Index}/{id:int?}");

            });
        }
    }
}
