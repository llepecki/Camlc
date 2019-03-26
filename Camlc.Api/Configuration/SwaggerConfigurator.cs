using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace Lepecki.Playground.Camlc.Api.Configuration
{
    public class SwaggerConfigurator
    {
        private readonly string _name;
        private readonly string _version;
        private readonly string _description;

        public SwaggerConfigurator(string name, string description, Version version)
        {
            _name = name;
            _description = description;
            _version = $"v{version.ToString(2)}";
        }

        public void SetupSwaggerGen(SwaggerGenOptions options)
        {
            options.SwaggerDoc(_version, new Info { Title = _name, Version = _version, Description = _description });
        }

        public void SetupSwaggerUi(SwaggerUIOptions options)
        {
            options.SwaggerEndpoint($"/swagger/{_version}/swagger.json", $"{_name} {_version}");
            options.RoutePrefix = string.Empty;
        }
    }
}
