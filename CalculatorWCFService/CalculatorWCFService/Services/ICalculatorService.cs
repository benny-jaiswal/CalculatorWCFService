using System.ServiceModel.Web;
using System.ServiceModel;
using CalculatorWCFService.App_Code;

namespace CalculatorWCFService.Services
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/calculate/json", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MathsResponse EvaluateJson( MathsRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/calculate/xml", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        MathsResponse EvaluateXml([MessageParameter(Name = "Maths")] MathsRequest request);
    }
}