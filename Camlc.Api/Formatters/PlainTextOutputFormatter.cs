using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lepecki.Playground.Camlc.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Lepecki.Playground.Camlc.Api.Formatters
{
    public class PlainTextOutputFormatter : StringOutputFormatter
    {
        public PlainTextOutputFormatter()
        {
            SupportedMediaTypes.Add("text/plain");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            return type == typeof(ExprResult[]);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context.Object is ExprResult[] exprResults)
            {
                await context.HttpContext.Response.WriteAsync(string.Join(Environment.NewLine, exprResults.Select(result => $"{result.Expr}={result.Result}")));
            }
            else
            {
                await context.HttpContext.Response.WriteAsync(string.Empty);
            }
        }
    }
}
