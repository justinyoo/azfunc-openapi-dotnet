using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using NetCoreApp31.FunctionApp.IoC.Models;
using NetCoreApp31.FunctionApp.IoC.Services;

namespace NetCoreApp31.FunctionApp.IoC
{
    public class NetCoreApp31HttpTrigger
    {
        private readonly IMyService _service;

        public NetCoreApp31HttpTrigger(IMyService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [OpenApiOperation(operationId: "greeting", tags: new[] { "greeting" }, Summary = "Greetings", Description = "This shows a welcome message.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter("name", Type = typeof(string), In = ParameterLocation.Query, Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Greeting), Summary = "The response", Description = "This returns the response")]

        [FunctionName("NetCoreApp31HttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "greetings")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            var instance = await this._service.GreetAsync(name).ConfigureAwait(false);

            return new OkObjectResult(instance);
        }
    }
}
