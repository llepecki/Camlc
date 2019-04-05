using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lepecki.Playground.Camlc.Api.Filters
{
    public class IncludeEnvironmentHeaderFilter : IResourceFilter
    {
        private readonly string _environment;

        public IncludeEnvironmentHeaderFilter(string environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Environment", _environment);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
