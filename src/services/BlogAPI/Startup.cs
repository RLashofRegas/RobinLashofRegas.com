using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

using BlogAPI.DataContext;
using BlogAPI.Options;
using BlogAPI.Providers;
using BlogAPI.Middleware;

namespace BlogAPI
{
    public class Startup
    {
        private const string webSpaCorsPolicyName = "com.RobinLashofRegas.webspa.cors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCustomDbContext(Configuration);

            services.AddCustomOptions(Configuration);

            services.AddCors(options => 
            {
                options.AddPolicy(webSpaCorsPolicyName, builder =>
                {
                    builder.WithOrigins(Configuration["WebspaUrl"])
                        .WithHeaders(HeaderNames.ContentType);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseCors(webSpaCorsPolicyName);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles(
                new StaticFileOptions 
                {
                    FileProvider = CreateIfNotExistsPhysicalFileProviderFactory
                        .Create(Configuration["ImagesPath"]),
                    RequestPath = "/Images",
                    ServeUnknownFileTypes = true,
                    DefaultContentType = "image/jpg"
                }
            );
        }
    }

    static class CustomStartupExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogContext>(options => 
            {
                options.UseMySql(configuration["ConnectionString"], (options) => {
                    options.EnableRetryOnFailure();
                });
            });

            return services;
        }

        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<AppOptions>(configuration);

            return services;
        }
    }
}
