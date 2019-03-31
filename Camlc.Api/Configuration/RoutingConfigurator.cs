using Microsoft.AspNetCore.Routing;
using System;

namespace Lepecki.Playground.Camlc.Api.Configuration
{
    public class RoutingConfigurator
    {
        public Action<RouteOptions> GetRoutingConfigurator()
        {
            return options =>  options.LowercaseUrls = true;
        }
    }
}
