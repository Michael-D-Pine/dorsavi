using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using backend.Interfaces;
using backend.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace sensorapi
{
    public class getcats
    {
        private readonly HttpClient _client;
        private readonly ISensor _service;

        public getcats(HttpClient client, ISensor service)
        {
            _client = client;
            _service = service;
        }

        [Function("getcats")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("getcats");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Context-Type", "application/json");

            var owners = await _service.GetCats();

            await response.WriteAsJsonAsync<IEnumerable<Owner>>(owners);

            return response;
        }
    }
}
