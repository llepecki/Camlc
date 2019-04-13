using System;
using System.Reflection;
using Com.Lepecki.Playground.Camlc.Api.Filters;
using Com.Lepecki.Playground.Camlc.Api.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public class StartupOptions : IStartupOptions
    {
        private readonly ApiVersion _apiVersion;
        private readonly string _name;
        private readonly string _version;
        private readonly string _description;
        private readonly string _environmentName;
        private readonly bool _isProduction;

        public StartupOptions(IHostingEnvironment environment)
        {
            Version semVersion = Assembly.GetAssembly(typeof(StartupOptions)).GetName().Version;

            _apiVersion = new ApiVersion(semVersion.Major, semVersion.Minor);
            _name = "Camlc API";
            _version = semVersion.ToString(2);
            _description = "Web calculator powered by Reverse Polish Notation";
            _environmentName = environment.EnvironmentName;
            _isProduction = environment.IsProduction();
        }

        public void Configure(ApiVersioningOptions options)
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = _apiVersion;
            options.ReportApiVersions = false;
            options.RouteConstraintName = "api-version";
        }

        public void Configure(ApiExplorerOptions options)
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        }

        public void Configure(MvcOptions options)
        {
            if (!_isProduction)
            {
                options.Filters.Add(new IncludeEnvironmentHeaderFilter(_environmentName));
            }

            options.Filters.Add(typeof(TaskCanceledExceptionFilter));

            options.OutputFormatters.RemoveType<StringOutputFormatter>();
            options.OutputFormatters.RemoveType<StreamOutputFormatter>();
            options.OutputFormatters.Add(new PlainTextOutputFormatter());
            options.OutputFormatters.Add(new CsvOutputFormatter());
            options.OutputFormatters.Add(new XmlOutputFormatter());
        }

        public void Configure(RouteOptions options)
        {
            options.LowercaseUrls = true;
        }

        public void Configure(SwaggerGenOptions options, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            options.OperationFilter<SwaggerDefaultValues>();

            foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new Info
                {
                    Title = _name,
                    Version = description.ApiVersion.ToString(),
                    Description = description.IsDeprecated ? $"{_description}. This API version has been deprecated." : _description
                });
            }
        }

        public void Configure(SwaggerUIOptions options, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            string suffix = _isProduction ? string.Empty : _environmentName;

            foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{_name} {description.GroupName.ToUpperInvariant()} {suffix}".Trim());
            }

            // options.SwaggerEndpoint($"/swagger/{_version}/swagger.json", $"{_name} {_version} {suffix}".Trim()); TODO: move above

            options.DocumentTitle = _name;
            options.RoutePrefix = string.Empty;
        }
    }
}
