using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Net50.FunctionApp.Static.Models;

namespace Net50.FunctionApp.Static
{
    public static class Net50HttpTrigger
    {
        [OpenApiOperation(operationId: "greeting", tags: new[] { "greeting" }, Summary = "Greetings", Description = "This shows a welcome message.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter("name", Type = typeof(string), In = ParameterLocation.Query, Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Greeting), Summary = "The response", Description = "This returns the response")]

        [Function("Net50HttpTrigger")]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "greetings")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Net5HttpTrigger");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var queries = QueryHelpers.ParseNullableQuery(req.Url.Query);
            var message = $"Hello, {queries["name"]}!";

            var response = req.CreateResponse(HttpStatusCode.OK);

            var instance = new Greeting() { Message = message };
            await response.WriteAsJsonAsync<Greeting>(instance).ConfigureAwait(false);

            return response;
        }
    }
}
