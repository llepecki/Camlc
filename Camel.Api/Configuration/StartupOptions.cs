namespace Lepecki.Playground.Camel.Api.Configuration
{
    public static class StartupOptions
    {
        static StartupOptions()
        {
            Routing = new RoutingConfigurator();
            
            Swagger = new SwaggerConfigurator
            {
                Name = "Camel API",
                Version = "v1",
                Description = "Web calculator powered by Reverse Polish Notation"
            };
        }

        public static RoutingConfigurator Routing { get; }

        public static SwaggerConfigurator Swagger { get; }
    }
}
