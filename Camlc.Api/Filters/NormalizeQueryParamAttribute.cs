using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.Camlc.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class NormalizeQueryParamAttribute : Attribute, IResourceFilter
    {
        private static readonly Regex WhiteSpaceRegex = new Regex(@"\s+");

        private readonly string _paramName;

        public NormalizeQueryParamAttribute(string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramName)) throw new ArgumentNullException(nameof(paramName));

            _paramName = paramName;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.HttpContext.Request.Query.ContainsKey(_paramName))
            {
                context.HttpContext.Request.Query = new QueryCollection(
                    context.HttpContext.Request.Query.ToDictionary(GetKey, GetValue));
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public bool RemoveWhiteSpaces { get; set; } = true;

        public bool ToUpperInvariant { get; set; } = true;

        private string GetKey(KeyValuePair<string, StringValues> param)
        {
            return param.Key.Equals(_paramName, StringComparison.OrdinalIgnoreCase) ? _paramName : param.Key;
        }

        private StringValues GetValue(KeyValuePair<string, StringValues> param)
        {
            if (param.Key.Equals(_paramName, StringComparison.OrdinalIgnoreCase))
            {
                var values = new string[param.Value.Count];

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = param.Value[i];

                    if (RemoveWhiteSpaces)
                    {
                        values[i] = WhiteSpaceRegex.Replace(values[i], string.Empty);
                    }

                    if (ToUpperInvariant)
                    {
                        values[i] = values[i].ToUpperInvariant();
                    }
                }

                return new StringValues(values);
            }

            return param.Value;
        }
    }
}
