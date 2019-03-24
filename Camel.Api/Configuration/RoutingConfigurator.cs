using Microsoft.AspNetCore.Routing;

namespace Lepecki.Playground.Camel.Api.Configuration
{
    public class RoutingConfigurator
    {
        public void SetupRoutingOptions(RouteOptions options)
        {
            options.LowercaseUrls = true;
        }
    }
}
