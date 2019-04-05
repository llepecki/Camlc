using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace Lepecki.Playground.Camlc.Api.Helpers
{
    public static class HttpContextHelper
    {
        public static void RewriteQueryParam(
            this ActionContext context,
            string paramName,
            StringValues values)
        {
            context.HttpContext.Request.Query = new QueryCollection(
                context.HttpContext.Request.Query.ToDictionary(
                    pair => pair.Key.Equals(paramName) ? paramName : pair.Key,
                    pair => pair.Key.Equals(paramName) ? values : pair.Value));
        }

        public static void RewriteQueryParam(
            this ActionContext context,
            string paramName,
            Func<string, string> paramNameSelector,
            Func<StringValues, StringValues> paramValuesSelector)
        {
            context.HttpContext.Request.Query = new QueryCollection(
                context.HttpContext.Request.Query.ToDictionary(
                    pair => pair.Key.Equals(paramName) ? paramNameSelector(pair.Key) : pair.Key,
                    pair => pair.Key.Equals(paramName) ? paramValuesSelector(pair.Value) : pair.Value));
        }
    }
}
