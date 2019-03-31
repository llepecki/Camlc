using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System;

namespace Lepecki.Playground.Camlc.Api.Configuration
{
    public class ApiVersioningConfigurator
    {
        private const string ApiVersionHeader = "Api-Version";

        private readonly Version _version;

        public ApiVersioningConfigurator(Version version)
        {
            _version = version ?? throw new ArgumentNullException(nameof(version));
        }

        public Action<ApiVersioningOptions> GetApiVersioningConfigurator()
        {
            return options =>
            {
                options.ApiVersionReader = new HeaderApiVersionReader(ApiVersionHeader);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(_version.Major, _version.Minor);
                options.ReportApiVersions = true;
            };
        }
    }
}
