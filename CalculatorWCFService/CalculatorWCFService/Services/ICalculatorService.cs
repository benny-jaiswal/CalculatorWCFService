using System.ServiceModel.Web;
using System.ServiceModel;
using CalculatorWCFService.App_Code;
using System;
using System.Xml.Linq;

namespace CalculatorWCFService.Services
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/calculate/json", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        JsonResponse EvaluateJson( JsonRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/calculate/xml", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        XmlResponse EvaluateXml( XmlRequest request);
    }
}