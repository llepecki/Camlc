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
    }
}
