using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore;
using C_Bageri_20.Models;

namespace C_Bageri_20
{
    // konfigurerar applikationen inf�r k�rning
    public class Startup
    {
        // anv�nds f�r databas (Entity Framework)
        public IConfiguration Configuration { get; }

        // construktor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // service collection, dependency injection
        // registrera de tj�nster som ska anv�ndas
        // instanser av de olika klasserna skapas h�r
        public void ConfigureServices(IServiceCollection services)
        {
            // databas-konfigurering
            // registrering av databas
            // specificerar vilken databas (Entity Framework)
            // <AppDbContext> = Model-klass f�r databasen
            // GetConnectionString h�mtar info fr�n appsettings.json

/*            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString
                    ("DefaultConnection")));*/

            // ska n�s fr�n alla st�llen i applikationen
            // skapar ny instans f�r varje request, f�rsvinner n�r 
            // "request" �r f�rdigbehandlad
            // interface, databaskoppling
            //services.AddScoped<IProdukt, ProductRepository>();

            // RepositoryMock �r testdata
            services.AddScoped<IProduct, ProductRepositoryMock>();
            services.AddScoped<IContact, ContactRepositoryMock>();

            // skapar ny instans varje g�ng
            //services.AddTransient

            // skapar en enda instans f�r hela applikationen
            // instansen �teranv�ndes
            //services.AddSingleton()

            // registrera support f�r MVC
            services.AddControllersWithViews();
        }

        // S.k. middleware-komponenter
        // s�tter upp request pipeline
        // komponenter som vill f�nga upp och hantera http-request  
        // och producera http-respons
        // komponenterna jobbar i en kedja efter varandra
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // exeption-info, endast f�r utvecklingsmilj� 
                app.UseDeveloperExceptionPage();
            }

            // http.request omdirigeras
            app.UseHttpsRedirection();

            // statiska filer, tex bilder
            // letar under mappen wwwroot
            app.UseStaticFiles();

            // request ska dirigeras till: controller + action-metod
            app.UseRouting();

            // Om ingen slutstation har beg�rts visas hemsidan
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    // 3:e parameter-namn samma som i action-metoden
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // info-medd f�r vanligt f�rekommande fel
            //app.UseStatusCodePages();
        }
    }
}
