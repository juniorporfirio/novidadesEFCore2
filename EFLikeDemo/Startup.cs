using System;
using EFLikeDemo.Contexto;
using EFLikeDemo.Models;
using GenFu;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFLikeDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<EFDemoContexto>(
                options => options.UseSqlServer(Configuration["ConfigurationStrings:Local"])
                );
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EFDemoContexto context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            var age = new Random();

            A.Configure<Artista>()
                .Fill(i => i.Idade).WithinRange(18,60)
                .Fill(n => n.Nome).AsFirstName()
                .Fill(s => s.Sobrenome).WithRandom(new[] {"Silva", "Maria", "Paulo"});

            var artistas = GenFu.GenFu.ListOf<Artista>(800);

            context.Artistas.AddRange(artistas);
            context.SaveChanges();



        }
    }
}
