using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Globalization;

namespace Lepecki.Playground.Camlc.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CacheResultForQueryParamAttribute : Attribute, IResourceFilter
    {
        private readonly string _paramName;

        public CacheResultForQueryParamAttribute(string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramName)) throw new ArgumentNullException(nameof(paramName));
            
            _paramName = paramName;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.HttpContext.Request.Query.ContainsKey(_paramName));
            {
                StringValues values = context.HttpContext.Request.Query[_paramName];

                if (values.Count == 1)
                {
                    var cache = GetCache(context);

                    if (cache.TryGetValue(values[0], out decimal result))
                    {
                        var contentResult = new ContentResult
                        {
                            StatusCode = 200,
                            Content = result.ToString(CultureInfo.InvariantCulture)
                        };

                        context.HttpContext.Response.Headers.Add("From-Cache", string.Empty);
                        context.Result = contentResult;
                    }
                }
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (context.Result is ObjectResult result)
            {
                decimal value = (decimal) result.Value;
                
                IMemoryCache cache = GetCache(context);

                cache.Set(context.HttpContext.Request.Query[_paramName][0], value);
            }
        }

        private IMemoryCache GetCache(FilterContext context)
        {
            return (IMemoryCache) context.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
        }
    }
}
