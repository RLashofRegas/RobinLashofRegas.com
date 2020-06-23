using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using BlogAPI.Providers;
using BlogAPI.Middleware;
using System.IO;

namespace BlogAPI
{
    public class Startup
    {
        private const string CORS_POLICY_NAME = "com.RobinLashofRegas.webspa.cors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddControllers();

            _ = services.AddCustomDbContext(Configuration);

            _ = services.AddCustomOptions(Configuration);

            _ = services.AddCors(
                options => options
                    .AddPolicy(CORS_POLICY_NAME,
                        builder => _ = builder
                            .WithOrigins(Configuration["WebspaUrl"])
                            .WithHeaders(HeaderNames.ContentType)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseMiddleware<RequestResponseLoggingMiddleware>();

            _ = app.UseCors(CORS_POLICY_NAME);

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints => endpoints.MapControllers());

            _ = app.UseStaticFiles(
                new StaticFileOptions {
                    FileProvider = CreateIfNotExistsPhysicalFileProviderFactory
                        .Create(Configuration["ImagesPath"]),
                    RequestPath = "/api/v1/Images",
                    ServeUnknownFileTypes = true,
                    DefaultContentType = "image/jpg"
                }
            );

            _ = app.UseStaticFiles(
                new StaticFileOptions {
                    FileProvider = CreateIfNotExistsPhysicalFileProviderFactory
                        .Create(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages")),
                    RequestPath = "/api/v1/SeedImages"
                }
            );
        }
    }
}
