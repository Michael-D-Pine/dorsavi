using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using backend.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace sensorapi
{
    public class add
    {
        private readonly ISensor _service;

        public add(ISensor service)
        {
            _service = service;
        }

        [Function("add/{a:int}/{b:int}")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext, int a, int b)
        {
            var logger = executionContext.GetLogger("add");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Context-Type", "application/json");

            var result = _service.AddUsingC(a, b);

            response.WriteString(result.ToString());

            return response;
        }
    }
}
