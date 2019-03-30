using Microsoft.AspNetCore.Routing;

namespace Lepecki.Playground.Camlc.Api.Configuration
{
    public class RoutingConfigurator
    {
        public void SetupRouting(RouteOptions options)
        {
            options.LowercaseUrls = true;
        }
    }
}
