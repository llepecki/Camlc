using Microsoft.Extensions.DependencyInjection;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public static class StartupOptions
    {
        public static IServiceCollection AddStartupOptions(this IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureOptions<ApiVersioningOptionsConfigurator>();
            serviceCollection.ConfigureOptions<MvcOptionsConfigurator>();
            serviceCollection.ConfigureOptions<RouteOptionsConfigurator>();
            serviceCollection.ConfigureOptions<SwaggerOptionsConfigurator>();

            return serviceCollection;
        }
    }
}
