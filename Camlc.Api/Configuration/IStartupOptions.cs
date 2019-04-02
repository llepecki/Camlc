using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Lepecki.Playground.Camlc.Api.Configuration
{
    public interface IStartupOptions :
        IConfigurator<ApiVersioningOptions>,
        IConfigurator<MvcOptions>,
        IConfigurator<RouteOptions>,
        IConfigurator<SwaggerGenOptions>,
        IConfigurator<SwaggerUIOptions>
    {
        // Action<ApiVersioningOptions> ApiVersioningConfigurator { get; }
        // 
        // Action<MvcOptions> MvcConfigurator { get; }
        // 
        // Action<RouteOptions> RoutingConfigurator { get; }
        // 
        // Action<SwaggerGenOptions> SwaggerGenConfigurator { get; }
        // 
        // Action<SwaggerUIOptions> SwaggerUiConfigurator { get; }
    }
}
