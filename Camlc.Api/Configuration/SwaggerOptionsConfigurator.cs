using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public class SwaggerOptionsConfigurator : IConfigureOptions<SwaggerGenOptions>, IConfigureOptions<SwaggerUIOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;
        private readonly IHostingEnvironment _environment;

        public SwaggerOptionsConfigurator(IApiVersionDescriptionProvider provider, IHostingEnvironment environment)
        {
            _apiVersionDescriptionProvider = provider ?? throw new ArgumentNullException(nameof(provider));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        public void Configure(SwaggerUIOptions options)
        {
            foreach (ApiVersionDescription description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                string nameSuffix = description.IsDeprecated ? " (deprecated)" : string.Empty;
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{description.GroupName}{nameSuffix}");
            }

            options.DocumentTitle = "Camlc API";
            options.RoutePrefix = string.Empty;
        }

        private Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            string titleSuffix = _environment.IsProduction() ? string.Empty : $" - {_environment.EnvironmentName}";

            var info = new Info
            {
                Title = $"Camlc API{titleSuffix}",
                Version = description.ApiVersion.ToString("'v'V"),
                Description = "Reverse Polish Notation powered calculator exposed via ASP.NET Core Web API"
            };

            return info;
        }
    }
}
