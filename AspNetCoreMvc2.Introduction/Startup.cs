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
using Microsoft.Extensions.Configuration;
using AspNetCoreMvc2.Introduction.Identity;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvc2.Introduction
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //UY-200405
            //Kendimiz route yapabilmek için EnableEndpointRouting set etmemiz gerekiyor.
            services.AddMvc(option => option.EnableEndpointRouting = false);

            //UY-200412
            //Madde 25 DbContext'e connectionstring tanımlama
            services.AddDbContext<UylmzDbContext>(options => options.UseSqlServer(_configuration["DbConnection"]));
            
            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => 
            {
                //Password Options
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                //Password Lock
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                //Unique Email
                options.User.RequireUniqueEmail = true;

                //Require
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = true;
            });

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

            //Session
            services.AddSession();
            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            //Eğer Development seçili ise developer için exception page gösterilecektir.
            env.EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName.Development;
            //Eğer Production seçili ise son kullanıcıya alınan exception gösterilmeyecektir.
            env.EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName.Production;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Eğer exception alınırsa bunun son kullanıcıya anlamlı şekilde gösterilmesi için yapılması gereken işlem.
                //CommonController içerisinde bir hata sayfasına gidecek.
                //.Net Core ile gelen yöntem
                app.UseExceptionHandler("/error");
            }
            //UY-200405
            //Route yapısı Controller/Action
            //app.UseMvcWithDefaultRoute(); //Default route yapısı için yazılabilir

            app.UseSession();


            //UY-200407
            app.UseMvc(configureRoutes);
        }


        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Default}/{action=Index2}/{Id?}");
            routeBuilder.MapRoute("MyRoute", "Engin/{controller=Default}/{action=Index3}/{Id?}");
            routeBuilder.MapRoute(name: "areas",template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );

        }
    }
}
