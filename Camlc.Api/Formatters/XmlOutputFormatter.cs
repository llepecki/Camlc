using Lepecki.Playground.Camlc.Api.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Xml;

namespace Lepecki.Playground.Camlc.Api.Formatters
{
    public class XmlOutputFormatter : XmlSerializerOutputFormatter
    {
        private static readonly XmlWriterSettings Settings = new XmlWriterSettings();
        
        public XmlOutputFormatter() : base(Settings)
        {
        }

        protected override bool CanWriteType(Type type)
        {
            return type == typeof(ExprResult[]);
        }
    }
}
