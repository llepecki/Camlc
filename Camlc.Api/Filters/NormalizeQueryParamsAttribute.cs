using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.Camlc.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NormalizeQueryParamsAttribute : Attribute, IResourceFilter
    {
        private static readonly Regex WhiteSpaceRegex = new Regex(@"\s+");

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Request.Query = new QueryCollection(
                context.HttpContext.Request.Query.ToDictionary(GetKey, GetNormalizedValue));
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        private static string GetKey(KeyValuePair<string, StringValues> param)
        {
            return param.Key;
        }

        public bool RemoveWhiteSpaces { get; set; } = true;

        public bool ToUpperInvariant { get; set; } = true;

        private StringValues GetNormalizedValue(KeyValuePair<string, StringValues> param)
        {
            var normalizedStringValues = new string[param.Value.Count];

            for (int i = 0; i < normalizedStringValues.Length; i++)
            {
                string value = param.Value[i];

                if (RemoveWhiteSpaces)
                {
                    value = WhiteSpaceRegex.Replace(value, string.Empty);
                }

                if (ToUpperInvariant)
                {
                    value = value.ToUpperInvariant();
                }

                normalizedStringValues[i] = value;
            }

            return new StringValues(normalizedStringValues);
        }
    }
}
