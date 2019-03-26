using System.Reflection;

namespace Lepecki.Playground.Camlc.Api.Configuration
{
    public static class StartupOptions
    {
        static StartupOptions()
        {
            var version = Assembly.GetAssembly(typeof(Startup)).GetName().Version;
            
            Routing = new RoutingConfigurator();
            ApiVersioning = new ApiVersioningConfigurator(version);
            Swagger = new SwaggerConfigurator("Camlc API", "Web calculator powered by Reverse Polish Notation", version);
        }

        public static RoutingConfigurator Routing { get; }
        
        public static ApiVersioningConfigurator ApiVersioning { get; }

        public static SwaggerConfigurator Swagger { get; }
    }
}
