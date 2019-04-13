using Com.Lepecki.Playground.Camlc.Api.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Text.RegularExpressions;

namespace Com.Lepecki.Playground.Camlc.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class NormalizeQueryParamFilter : Attribute, IResourceFilter
    {
        private static readonly Regex WhiteSpaceRegex = new Regex(@"\s+");

        private readonly string _paramName;

        public NormalizeQueryParamFilter(string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramName)) throw new ArgumentNullException(nameof(paramName));

            _paramName = paramName;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.RewriteQueryParam(_paramName, NormalizeParamName, NormalizeParamValues);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public bool RemoveWhiteSpaces { get; set; } = true;

        public bool ToUpperInvariant { get; set; } = true;

        private string NormalizeParamName(string param)
        {
            return _paramName;
        }

        private StringValues NormalizeParamValues(StringValues values)
        {
            var normalized = new string[values.Count];

            for (int i = 0; i < normalized.Length; i++)
            {
                normalized[i] = values[i];

                if (RemoveWhiteSpaces)
                {
                    normalized[i] = WhiteSpaceRegex.Replace(normalized[i], string.Empty);
                }

                if (ToUpperInvariant)
                {
                    normalized[i] = normalized[i].ToUpperInvariant();
                }
            }

            return new StringValues(normalized);
        }
    }
}
