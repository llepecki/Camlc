using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Lepecki.Playground.Camel.Api
{
    public class SwaggerConfigurator
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public void SetupGenOptions(SwaggerGenOptions options)
        {
            options.SwaggerDoc(Version, new Info { Title = Name, Version = Version });
        }

        public void SetupUiOptions(SwaggerUIOptions options)
        {
            options.SwaggerEndpoint($"/swagger/{Version}/swagger.json", $"{Name} {Version}");
            options.RoutePrefix = string.Empty;
        }
    }
}
