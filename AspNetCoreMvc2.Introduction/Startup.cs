using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.DataSources;
using AspNetCoreMvc2.Introduction.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;



namespace AspNetCoreMvc2.Introduction
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //UY-200405
            //Kendimiz route yapabilmek için EnableEndpointRouting set etmemiz gerekiyor.
            services.AddMvc(option => option.EnableEndpointRouting = false);

            //UY-200412
            //Madde 25 DbContext'e connectionstring tanımlama
            var connectionString = "Data Source=mssql07.turhost.com;Initial Catalog=UylmzDB;Persist Security Info=True;User ID=uylmz96;Password=Umut5546@";
            services.AddDbContext<UylmzDbContext>(options=>options.UseSqlServer(connectionString));
            
            //UY-200412
            //Madde 22 nin hangi yöntem ile çalışacağını belirtiyoruz.
            //Yani ICalculator çağırılırsa Calculator18 üret demiş olduk.

            //Singelton Pattern ile nesneyi üretir. Uygulma çalışırken sadece 1 tane instance oluşur.
            services.AddSingleton<ICalculator, Calculator18>();
            //Singelton Patternden farklı olarak her istekte bir instance üretilir.
            services.AddScoped<ICalculator, Calculator18>();
            //Scoped dan farkı bir yerde 2 tane nesne üretilir ise 
            //Scoped 1 tane üretir ve ikisine de aynı referansı tanımlar
            //Transient da ise 2 nesne içinde 2 tane farklı nesne üretilir ve farklı referanslarda olmuş olurlar
            services.AddTransient<ICalculator, Calculator18>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //UY-200405
            //Route yapısı Controller/Action
            //app.UseMvcWithDefaultRoute(); //Default route yapısı için yazılabilir

            //UY-200407
            app.UseMvc(configureRoutes);
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Default}/{action=Index2}/{Id?}");
            routeBuilder.MapRoute("MyRoute", "Engin/{controller=Default}/{action=Index3}/{Id?}");

        }
    }
}
