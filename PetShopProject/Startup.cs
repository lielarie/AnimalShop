using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AnimalShopProject.Data;
using AnimalShopProject.Models;

namespace AnimalShopProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=(localdb)\\AnimalShopProject;Database=AnimalsProject;Trusted_Connection=true";
            services.AddDbContext<AnimalContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, AnimalContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=AnimalShop}/{action=MainPage}");
            });
        }
    }
}
