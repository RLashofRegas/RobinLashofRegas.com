using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using BlogAPI.Providers;
using BlogAPI.Middleware;
using System.IO;

namespace BlogAPI
{
    public class Startup
    {
        private const string CorsPolicyName = "com.RobinLashofRegas.webspa.cors";

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddControllers();

            _ = services.AddCustomDbContext(this.Configuration);

            _ = services.AddCustomOptions(this.Configuration);

            _ = services.AddCors(
                options => options
                    .AddPolicy(CorsPolicyName,
                        builder => _ = builder
                            .WithOrigins(this.Configuration["WebspaUrl"])
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

            _ = app.UseCors(CorsPolicyName);

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints => endpoints.MapControllers());

            _ = app.UseStaticFiles(
                new StaticFileOptions {
                    FileProvider = CreateIfNotExistsPhysicalFileProviderFactory
                        .Create(this.Configuration["ImagesPath"]),
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
