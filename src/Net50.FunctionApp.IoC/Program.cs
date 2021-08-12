using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Net50.FunctionApp.IoC.Services;

namespace Net50.FunctionApp.IoC
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
                .ConfigureOpenApi()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IMyService, MyService>();
                })
                .Build();

            host.Run();
        }
    }
}