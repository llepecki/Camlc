using Com.Lepecki.Playground.Camlc.Api.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using Com.Lepecki.Playground.Camlc.Api.Models;

namespace Com.Lepecki.Playground.Camlc.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CacheResultForQueryParamFilter : Attribute, IResourceFilter, IActionFilter
    {
        private readonly string _paramName;
        private readonly string _cachedExprResultsKey;

        public CacheResultForQueryParamFilter(string paramName, string cachedExprResultsKey)
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
                IMemoryCache cache = GetCache(context);
                (ExprResult[] fromCache, string[] notInCache) = GetExprResultsFromCache(context.HttpContext.Request.Query[_paramName], cache);

                if (fromCache.Length > 0)
                {
                    context.HttpContext.Items.Add(_cachedExprResultsKey, fromCache);
                    string[] headers = fromCache.Select(result => result.Expr).ToArray();

                    if (headers.Length > 0)
                    {
                        context.HttpContext.Response.Headers.Add("From-Cache", new StringValues(headers));
                    }

                    context.RewriteQueryParam(_paramName, new StringValues(notInCache));
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
                        objectResult.Value = Merge(cachedResults, exprResults);
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

        private ExprResult[] Merge(ExprResult[] first, ExprResult[] second)
        {
            var allResults = new ExprResult[first.Length + second.Length];

            for (int i = 0; i < first.Length; i++)
            {
                allResults[i] = first[i];
            }

            for (int i = 0; i < second.Length; i++)
            {
                allResults[i + first.Length] = second[i];
            }

            return allResults;
        }
    }
}
