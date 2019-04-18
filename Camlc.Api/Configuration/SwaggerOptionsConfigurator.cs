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
            foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        public void Configure(SwaggerUIOptions options)
        {
            string suffix = _environment.IsProduction() ? string.Empty : _environment.EnvironmentName;

            foreach (ApiVersionDescription description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"[name] {description.GroupName.ToUpperInvariant()} {suffix}".Trim());
            }

            options.DocumentTitle = "[document title]";
            options.RoutePrefix = string.Empty;
        }

        static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info
            {
                Title = "Sample API",
                Version = description.ApiVersion.ToString(),
                Description = "A sample application with Swagger, Swashbuckle, and API versioning.",
                Contact = new Contact { Name = "Bill Mei", Email = "bill.mei@somewhere.com" },
                TermsOfService = "Shareware",
                License = new License { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
