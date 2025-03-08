using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CalculatorWCFService.App_Code
{
    [DataContract(Namespace = "http://tempuri.org/")]
    [XmlRoot("EvaluateXml", Namespace = "http://tempuri.org/")]
    public class MathsRequest
    {
        [DataMember]
        [XmlElement("Maths")]
        public Maths Maths { get; set; }
    }

    [DataContract(Namespace = "http://tempuri.org/")]
    public class Maths
    {
        [DataMember]
        [XmlElement("Operation")]
        public Operation Operation { get; set; }
    }

    [DataContract(Namespace = "http://tempuri.org/")]
    public class Operation
    {
        [DataMember]
        [XmlAttribute("ID")]
        [JsonProperty("ID")]
        public string Id { get; set; }

        [DataMember]
        [XmlElement("Value")]
        [JsonProperty("Value")]
        public List<double> Values { get; set; }

        [DataMember]
        [XmlElement("InnerOperation")]
        [JsonProperty("InnerOperation")]
        public Operation InnerOperation { get; set; }

        // Constructor to initialize the list
        public Operation()
        {
            Values = new List<double>();
        }
    }
}