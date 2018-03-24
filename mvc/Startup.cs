using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mvc.Data;
using mvc.Repository;

namespace mvc
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetSection("ConnectionString")["BancoDaAula4"]));
            services.AddMvc();
            Console.WriteLine("Database Connection: "+ Configuration.GetConnectionString("BancoDaAula4"));
            //injeção de dependência
            services.AddTransient<IPeopleRepository>(repository => new PeopleRepository("http://sqlserver"));
            //services.AddScoped(); //por requisição
            //services.AddSingleton() //unica instância
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
                        template: "{controller=Home}/{action=Index}/{id?}")
                    .MapRoute(
                        name: "about-rout",
                        template: "about",
                        defaults: new { controller = "Home", action = "About"}
                    )
                    .MapRoute(
                        name: "contact-rout",
                        template: "contact",
                        defaults: new { controller = "Home", action = "Contact"}
                    );
            });
        }
    }
}
