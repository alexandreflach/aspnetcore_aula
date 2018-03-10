using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            //asp core 1.0
           //var host = new WebHostBuilder()
           //    .UseKestrel()
           //    .UseStartup<Startup>()
           //    .UseContentRoot(Directory.GetCurrentDirectory())
           //    .Build();
           //host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}
