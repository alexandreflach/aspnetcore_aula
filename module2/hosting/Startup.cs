using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace hosting
{

    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            //asp core 1.0
           //var builder = new ConfigurationBuilder()
           //    .SetBasePath(env.ContentRootPath)
           //    .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
           //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
           //    .AddEnvironmentVariables();

           //builder.AddEnvironmentVariables();
           //_configuration = builder.Build();
        }
        public void Configure(IApplicationBuilder app)
        {
            //usando middleware exemplo
            //app.Use(async(context, next) =>{
            //    context.Response.Headers.Add("Middleware", "APRENDENDO");
            //    await next.Invoke();
            //});


            app.UseMiddleware<MyMiddleware>();
            app.UseStaticFiles();
            var applicationName = Configuration.GetValue<string>("ApplicationName");
            app.Run(
                context =>
                    context.Response.WriteAsync($"ola mundo 2 |{applicationName}")
            );
        }
    }
}