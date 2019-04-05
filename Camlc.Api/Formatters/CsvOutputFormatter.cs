using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Lepecki.Playground.Camlc.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Hosting;

namespace Lepecki.Playground.Camlc.Api.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedMediaTypes.Add("application/csv");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            return type == typeof(ExprResult[]);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var builder = new StringBuilder($"Expr,Result{Environment.NewLine}");

            if (context.Object is ExprResult[] exprResults)
            {
                foreach (ExprResult result in exprResults)
                {
                    builder.AppendFormat("{0},{1}{2}", result.Expr, result.Result.ToString(CultureInfo.InvariantCulture), Environment.NewLine);
                }
            }

            await context.HttpContext.Response.WriteAsync(builder.ToString());
        }
    }
}
