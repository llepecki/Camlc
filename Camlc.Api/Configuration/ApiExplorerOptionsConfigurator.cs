using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public class ApiExplorerOptionsConfigurator : IConfigureOptions<ApiExplorerOptions>
    {
        public void Configure(ApiExplorerOptions options)
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        }
    }
}
