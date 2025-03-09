using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CalculatorWCFService.App_Code
{
    // Root element <EvaluateXml> with no namespace
    [DataContract(Name = "EvaluateXml", Namespace = "")]
    [XmlRoot("EvaluateXml", Namespace = "")]
    public class XmlRequest
    {
        // Matches <Maths> element
        [DataMember]
        [XmlElement("Maths", Namespace = "")]
        public XmlMaths Maths { get; set; }
    }

    [DataContract(Namespace = "")]
    public class XmlMaths
    {
        [DataMember]
        [XmlElement("Operation", Namespace = "")]
        public XmlOperation Operation { get; set; }
    }

    [DataContract(Namespace = "")]
    public class XmlOperation
    {
        [DataMember]
        [XmlAttribute("Id")] // The attribute is "ID" with no namespace
        public string Id { get; set; }

        // Each <Value> element
        [DataMember]
        [XmlElement("Values", Namespace = "")]
        public List<double> Values { get; set; }

        // Nested <Operation> for the inner operation
        [DataMember]
        [XmlElement("Operation", Namespace = "")]
        public XmlOperation InnerOperation { get; set; }

        public XmlOperation()
        {
            Values = new List<double>();
        }
    }
}
