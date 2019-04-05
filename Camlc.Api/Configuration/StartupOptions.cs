using Lepecki.Playground.Camlc.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Reflection;
using Lepecki.Playground.Camlc.Api.Formatters;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Lepecki.Playground.Camlc.Api.Configuration
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
            options.ApiVersionReader = new HeaderApiVersionReader("Api-Version");
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = _apiVersion;
            options.ReportApiVersions = false;
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

        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc(_version, new Info
            {
                Title = _name,
                Version = _version,
                Description = _description
            });
        }

        public void Configure(SwaggerUIOptions options)
        {
            string suffix = _isProduction ? string.Empty : _environmentName;

            options.SwaggerEndpoint($"/swagger/{_version}/swagger.json", $"{_name} {_version} {suffix}".Trim());
            options.DocumentTitle = _name;
            options.RoutePrefix = string.Empty;
        }
    }
}
