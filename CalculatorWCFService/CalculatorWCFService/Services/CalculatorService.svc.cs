using CalculatorWCFService.App_Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;
using System.Xml;

namespace CalculatorWCFService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculatorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalculatorService.svc or CalculatorService.svc.cs at the Solution Explorer and start debugging.
    public class CalculatorService : ICalculatorService
    {
        public JsonResponse EvaluateJson(JsonRequest request)
        {
            if (request == null || request.Maths.Operation == null)
            {
                throw new ArgumentNullException("Received a null request!");
            }

            Console.WriteLine("Received XML Request:");
            Console.WriteLine(JsonConvert.SerializeObject(request, Newtonsoft.Json.Formatting.Indented));
            return new JsonResponse { Results = Evaluate(request.Maths.Operation) };
        }

        public XmlResponse EvaluateXml(XmlRequest request)
        {
            
            if (request == null || request.Maths == null || request.Maths.Operation == null)
            {
                throw new ArgumentNullException("Request is null or missing required fields!");
            }

            Console.WriteLine("Received XML Request (as object):");
            Console.WriteLine(JsonConvert.SerializeObject(request, Newtonsoft.Json.Formatting.Indented));

            // 3. Do your logic
            // Evaluate() is presumably your calculation method
            List<XmlOperationResult> results = EvaluateXml(request.Maths.Operation);

            // 4. Return the response
            return new XmlResponse { Results = results };
        }



        
        private List<OperationResult> Evaluate(Operation operation)
        {
            List<OperationResult> results = new List<OperationResult>();

            // Compute the current operation result
            double result = PerformOperation(operation.Id, operation.Values);

            // Store the result with the operation ID
            results.Add(new OperationResult
            {
                Id = operation.Id,
                Result = result
            });

            // Recursively compute inner operations (if any) and collect results
            if (operation.InnerOperation != null)
            {
                results.AddRange(Evaluate(operation.InnerOperation));
            }

            return results;
        }

        private List<XmlOperationResult> EvaluateXml(XmlOperation operation)
        {
            List<XmlOperationResult> results = new List<XmlOperationResult>();

            // Compute the current operation result
            double result = PerformOperation(operation.Id, operation.Values);

            // Store the result with the operation ID
            results.Add(new XmlOperationResult
            {
                Id = operation.Id,
                Result = result
            });

            // Recursively compute inner operations (if any) and collect results
            if (operation.InnerOperation != null)
            {
                results.AddRange(EvaluateXml(operation.InnerOperation));
            }

            return results;
        }

        private double PerformOperation(string operationId, List<double> values)
        {
            if (values == null || values.Count == 0)
                return 0;

            double result = values[0];

            for (int i = 1; i < values.Count; i++)
            {
                switch (operationId)
                {
                    case "Plus":
                        result += values[i];
                        break;
                    case "Subtraction":
                        result -= values[i];
                        break;
                    case "Multiplication":
                        result *= values[i];
                        break;
                    case "Division":
                        result = values[i] != 0 ? result / values[i] : double.NaN;
                        break;
                    default:
                        throw new ArgumentException($"Unknown operation: {operationId}");
                }
            }
            return result;
        }
    }
    
}