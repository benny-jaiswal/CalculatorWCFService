using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CalculatorWCFService.App_Code
{    
    [DataContract]
    public class JsonResponse
    {
        [DataMember]
        public List<OperationResult> Results { get; set; }
    }
    public class OperationResult
    {
        public string Id { get; set; }
        public double Result { get; set; }
    }
}