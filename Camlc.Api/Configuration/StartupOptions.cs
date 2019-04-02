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

            // ApiVersioningConfigurator = CreateApiVersioningConfigurator(semVersion);
            // MvcConfigurator = CreateMvcConfigurator();
            // RoutingConfigurator = CreateRoutingConfigurator();
            // SwaggerGenConfigurator = CreateSwaggerGenConfigurator(name, version, description);
            // SwaggerUiConfigurator = CreateSwaggerUiConfigurator(name, version, environment.IsProduction(), environment.EnvironmentName);
        }

        public void Configure(ApiVersioningOptions options)
        {
            options.ApiVersionReader = new HeaderApiVersionReader("Api-Version");
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = _apiVersion;
            options.ReportApiVersions = true;
        }

        public void Configure(MvcOptions options)
        {
            // TODO: add environment headers on stage and prod
            options.Filters.Add(typeof(TaskCanceledExceptionFilter));
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
            options.RoutePrefix = string.Empty;
        }

        // public Action<ApiVersioningOptions> ApiVersioningConfigurator { get; }
        // 
        // public Action<MvcOptions> MvcConfigurator { get; }
        // 
        // public Action<RouteOptions> RoutingConfigurator { get; }
        // 
        // public Action<SwaggerGenOptions> SwaggerGenConfigurator { get; }
        // 
        // public Action<SwaggerUIOptions> SwaggerUiConfigurator { get; }
// 
        // private Action<ApiVersioningOptions> CreateApiVersioningConfigurator(Version version)
        // {
        //     return options =>
        //     {
        //         options.ApiVersionReader = new HeaderApiVersionReader("Api-Version");
        //         options.AssumeDefaultVersionWhenUnspecified = true;
        //         options.DefaultApiVersion = new ApiVersion(version.Major, version.Minor);
        //         options.ReportApiVersions = true;
        //     };
        // }
        // 
        // private Action<MvcOptions> CreateMvcConfigurator()
        // {
        //     // TODO: add environment headers on stage and prod
        //     return options =>  options.Filters.Add(typeof(TaskCanceledExceptionFilter));
        // }
        // 
        // private Action<RouteOptions> CreateRoutingConfigurator()
        // {
        //     return options =>  options.LowercaseUrls = true;
        // }
        // 
        // private Action<SwaggerGenOptions> CreateSwaggerGenConfigurator(string name, string version, string description)
        // {
        //     return options => options.SwaggerDoc(version, new Info
        //     {
        //         Title = name,
        //         Version = version,
        //         Description = description
        //     });
        // }
        // 
        // private Action<SwaggerUIOptions> CreateSwaggerUiConfigurator(string name, string version, bool isProduction, string environmentName)
        // {
        //     string suffix = isProduction ? string.Empty : environmentName;
// 
        //     return options =>
        //     {
        //         options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{name} {version} {suffix}".Trim());
        //         options.RoutePrefix = string.Empty;
        //     };
        // }
    }
}
