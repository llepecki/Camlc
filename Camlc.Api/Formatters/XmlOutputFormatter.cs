using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Com.Lepecki.Playground.Camlc.Api.Models;

namespace Com.Lepecki.Playground.Camlc.Api.Formatters
{
    public class XmlOutputFormatter : TextOutputFormatter
    {
        private static readonly XmlWriterSettings Settings = new XmlWriterSettings();
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(SerializableExprResult));

        public XmlOutputFormatter()
        {
            SupportedMediaTypes.Add("application/xml");
            SupportedMediaTypes.Add("text/xml");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            return type == typeof(ExprResult) || type == typeof(ExprResult[]);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context.Object is ExprResult exprResult)
            {
                SerializableExprResult serializableExprResult = new SerializableExprResult(exprResult);
                await WriteAsync(context, serializableExprResult);
            }
            else if (context.Object is ExprResult[] exprResults)
            {
                SerializableExprResult serializableExprResult = new SerializableExprResult(exprResults);
                await WriteAsync(context, serializableExprResult);
            }
        }

        private async Task WriteAsync(OutputFormatterWriteContext context, SerializableExprResult result)
        {
            using (TextWriter writer = new StringWriter())
            {
                Serializer.Serialize(writer, result);
                await context.HttpContext.Response.WriteAsync(writer.ToString());
            }
        }
    }
}
