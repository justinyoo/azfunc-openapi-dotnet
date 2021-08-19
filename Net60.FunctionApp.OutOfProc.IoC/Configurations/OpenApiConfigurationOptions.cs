using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace Net60.FunctionApp.OutOfProc.IoC.Configurations
{
    public class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
    {
        public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
        {
            Version = "v6.0.0-outofproc-ioc",
            Title = "Azure Functions OpenAPI Extension with IoC Container, Running on .NET 6 Out-of-process Worker Environment",
            Description = "A sample API that runs on Azure Functions using OpenAPI specification, running on the out-of-process worker environment.",
            TermsOfService = new Uri("https://github.com/justinyoo/azfunc-openapi-dotnet"),
            Contact = new OpenApiContact()
            {
                Name = "Contoso",
                Email = "azfunc-openapi@contoso.com",
                Url = new Uri("https://github.com/justinyoo/azfunc-openapi-dotnet/issues"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        };

        public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;
    }
}
