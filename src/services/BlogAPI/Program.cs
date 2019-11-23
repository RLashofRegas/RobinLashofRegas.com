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
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger1 = services.GetRequiredService<ILogger<Program>>();
                var appOptions = services.GetRequiredService<IOptionsMonitor<AppOptions>>().CurrentValue;
                var fileName = Path.GetRandomFileName();
                var filePath = Path.Combine(appOptions.ImagesPath, fileName);
                logger1.LogDebug(filePath);


                try
                {
                    var context = services.GetRequiredService<BlogContext>();
                    context.Database.Migrate();
                    var seed = new BlogContextSeed();
                    seed.SeedAsync(context).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB");
                }
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
