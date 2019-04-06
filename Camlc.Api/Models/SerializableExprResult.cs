using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lepecki.Playground.Camlc.Api.Models
{
    public class SerializableExprResult // : IXmlSerializable
    {
        public SerializableExprResult()
        {
            Results = new ExprResult[0];
        }

        public SerializableExprResult(ExprResult result)
        {
            Results = new[] { result };
        }

        public SerializableExprResult(ExprResult[] results)
        {
            Results = results;
        }

        public ExprResult[] Results { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new System.NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}
