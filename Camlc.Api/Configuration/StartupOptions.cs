using Microsoft.Extensions.DependencyInjection;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public static class StartupOptions
    {
        public static IServiceCollection AddStartupOptions(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .ConfigureOptions<ApiExplorerOptionsConfigurator>()
                .ConfigureOptions<ApiVersioningOptionsConfigurator>()
                .ConfigureOptions<MvcOptionsConfigurator>()
                .ConfigureOptions<RouteOptionsConfigurator>()
                .ConfigureOptions<SwaggerOptionsConfigurator>();
        }
    }
}
