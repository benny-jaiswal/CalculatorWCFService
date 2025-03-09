using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CalculatorWCFService.App_Code
{    
    [DataContract]
    public class XmlResponse
    {
        [DataMember]
        public List<XmlOperationResult> Results { get; set; }
    }
    public class XmlOperationResult
    {
        public string Id { get; set; }
        public double Result { get; set; }
    }
}