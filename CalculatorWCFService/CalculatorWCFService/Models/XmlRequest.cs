using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CalculatorWCFService.App_Code
{
    // This class is dedicated to the WCF XML request
    [DataContract(Name = "EvaluateXml", Namespace = "http://tempuri.org/")]
    [XmlRoot("EvaluateXml", Namespace = "http://tempuri.org/")]
    public class XmlRequest
    {
        // Matches <Maths> element inside <EvaluateXml>
        [DataMember]
        [XmlElement("Maths", Namespace = "http://tempuri.org/")]
        public XmlMaths Maths { get; set; }
    }

    [DataContract(Namespace = "http://tempuri.org/")]
    public class XmlMaths
    {
        [DataMember]
        [XmlElement("Operation", Namespace = "http://tempuri.org/")]
        public XmlOperation Operation { get; set; }
    }

    [DataContract(Namespace = "http://tempuri.org/")]
    public class XmlOperation
    {
        [DataMember]
        [XmlAttribute("ID")]
        public string Id { get; set; }

        [DataMember]
        [XmlElement("Value")]
        public List<double> Values { get; set; }

        [DataMember]
        [XmlElement("Operation", Namespace = "http://tempuri.org/")]
        public XmlOperation InnerOperation { get; set; }

        public XmlOperation()
        {
            Values = new List<double>();
        }
    }
}
