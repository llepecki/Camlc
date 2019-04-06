using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Lepecki.Playground.Camlc.Api.Configuration
{
    public static class StartupOptionsExtensions
    {
        public static IWebHostBuilder UseStartup<TStartup, TStartupOptions>(this IWebHostBuilder builder)
            where TStartup : class
            where TStartupOptions : class, IStartupOptions
        {
            return builder
                .UseStartup<TStartup>()
                .ConfigureServices(serviceCollection => serviceCollection.AddTransient<IStartupOptions, TStartupOptions>());
        }
    }
}
