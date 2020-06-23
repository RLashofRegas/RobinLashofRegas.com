using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using BlogAPI.DataContext;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.Options;
using BlogAPI.Options;

namespace BlogAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                IOptionsMonitor<AppOptions> appOptions = services.GetRequiredService<IOptionsMonitor<AppOptions>>();
                BlogContext context = services.GetRequiredService<BlogContext>();
                context.Database.Migrate();
                BlogContextSeeder.SeedAsync(context).Wait();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => {
                    _ = logging.ClearProviders();
                    _ = logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder => _ = webBuilder.UseStartup<Startup>());
        }
    }
}
