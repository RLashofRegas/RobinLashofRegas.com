using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BlogAPI.DataContext;
using BlogAPI.Options;

namespace BlogAPI
{
    internal static class CustomStartupExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddDbContext<BlogContext>(
                dbContextOptions => _ = dbContextOptions
                    .UseMySql(configuration["ConnectionString"],
                        mySqlOptions => _ = mySqlOptions.EnableRetryOnFailure()));

            return services;
        }

        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddOptions();

            _ = services.Configure<AppOptions>(configuration);

            return services;
        }
    }
}
