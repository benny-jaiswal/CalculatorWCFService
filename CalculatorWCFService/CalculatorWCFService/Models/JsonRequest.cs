using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CalculatorWCFService.App_Code
{
    [DataContract(Namespace = "http://tempuri.org/")]
    public class JsonRequest
    {
        [DataMember]        
        public Maths Maths { get; set; }
    }

    [DataContract(Namespace = "http://tempuri.org/")]
    public class Maths
    {
        [DataMember]
        public Operation Operation { get; set; }
    }

    [DataContract(Namespace = "http://tempuri.org/")]
    public class Operation
    {
        [DataMember]        
        [JsonProperty("ID")]
        public string Id { get; set; }

        [DataMember]        
        [JsonProperty("Value")]
        public List<double> Values { get; set; }

        [DataMember]        
        [JsonProperty("InnerOperation")]
        public Operation InnerOperation { get; set; }

        // Constructor to initialize the list
        public Operation()
        {
            Values = new List<double>();
        }
    }
}