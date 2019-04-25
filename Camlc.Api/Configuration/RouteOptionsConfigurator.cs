using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public class RouteOptionsConfigurator : IConfigureOptions<RouteOptions>
    {
        public void Configure(RouteOptions options)
        {
            options.LowercaseUrls = true;
        }
    }
}
