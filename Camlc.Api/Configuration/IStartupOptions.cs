using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public interface IStartupOptions :
        IConfigurator<ApiVersioningOptions>,
        IConfigurator<ApiExplorerOptions>,
        IConfigurator<MvcOptions>,
        IConfigurator<RouteOptions>
    {
        void Configure(SwaggerUIOptions options, IApiVersionDescriptionProvider apiVersionDescriptionProvider);

        void Configure(SwaggerGenOptions options, IApiVersionDescriptionProvider apiVersionDescriptionProvider);
    }
}
