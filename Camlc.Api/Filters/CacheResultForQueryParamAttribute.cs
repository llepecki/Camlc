using Lepecki.Playground.Camlc.Api.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camlc.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CacheResultForQueryParamAttribute : Attribute, IResourceFilter, IActionFilter
    {
        private readonly string _paramName;
        private readonly string _cachedExprResultsKey;

        public CacheResultForQueryParamAttribute(string paramName, string cachedExprResultsKey)
        {
            if (string.IsNullOrWhiteSpace(paramName)) throw new ArgumentNullException(nameof(paramName));
            if (string.IsNullOrWhiteSpace(cachedExprResultsKey)) throw new ArgumentNullException(nameof(cachedExprResultsKey));

            _paramName = paramName;
            _cachedExprResultsKey = cachedExprResultsKey;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.HttpContext.Request.Query.ContainsKey(_paramName))
            {
                var cache = GetCache(context);

                (ExprResult[] fromCache, string[] notInCache) =
                    GetExprResultsFromCache(context.HttpContext.Request.Query[_paramName], cache);

                if (fromCache.Length > 0)
                {
                    context.HttpContext.Items.Add(_cachedExprResultsKey, fromCache);

                    string[] headers = fromCache.Select(result => result.Expr).ToArray();

                    if (headers.Length > 0)
                    {
                        context.HttpContext.Response.Headers.Add("From-Cache", new StringValues(headers));
                    }

                    context.HttpContext.Request.Query = new QueryCollection(
                        context.HttpContext.Request.Query.ToDictionary(pair => pair.Key, pair => new StringValues(notInCache)));
                }
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value is ExprResult[] exprResults)
            {
                IMemoryCache cache = GetCache(context);

                foreach (ExprResult exprResult in exprResults)
                {
                    cache.Set(exprResult.Expr, exprResult.Result);
                }

                if (context.HttpContext.Items.ContainsKey(_cachedExprResultsKey))
                {
                    if (context.HttpContext.Items[_cachedExprResultsKey] is ExprResult[] cachedResults)
                    {
                        var allResults = new ExprResult[cachedResults.Length + exprResults.Length];

                        for (int i = 0; i < cachedResults.Length; i++)
                        {
                            allResults[i] = cachedResults[i];
                        }

                        for (int i = 0; i < exprResults.Length; i++)
                        {
                            allResults[i + cachedResults.Length] = exprResults[i];
                        }

                        objectResult.Value = allResults;
                    }
                }
            }
        }

        private IMemoryCache GetCache(FilterContext context)
        {
            return (IMemoryCache)context.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
        }

        private (ExprResult[] fromCache, string[] notInCache) GetExprResultsFromCache(StringValues values, IMemoryCache cache)
        {
            var fromCache = new List<ExprResult>();
            var notInCache = new List<string>();

            foreach (string value in values)
            {
                if (cache.TryGetValue(value, out decimal result))
                {
                    fromCache.Add(new ExprResult { Expr = value, Result = result });
                }
                else
                {
                    notInCache.Add(value);
                }
            }

            return (fromCache.ToArray(), notInCache.ToArray());
        }
    }
}
