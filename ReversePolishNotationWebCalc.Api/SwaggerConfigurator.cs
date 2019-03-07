using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Api
{
    public static class SwaggerConfigurator
    {
        public static void SetupGenOptions(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        }
        
        public static void SetupUiOptions(SwaggerUIOptions options)
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            options.RoutePrefix = string.Empty;
        }
    }
}