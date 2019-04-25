using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public class ApiVersioningOptionsConfigurator : IConfigureOptions<ApiVersioningOptions>
    {
        private readonly ApiVersion _version;

        public ApiVersioningOptionsConfigurator()
        {
            Version assemblyVersion = Assembly.GetAssembly(typeof(StartupOptions)).GetName().Version;
            _version = new ApiVersion(assemblyVersion.Major, assemblyVersion.Minor);
        }

        public void Configure(ApiVersioningOptions options)
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = _version;
            options.ReportApiVersions = false;
            options.RouteConstraintName = "api-version";
        }
    }
}
