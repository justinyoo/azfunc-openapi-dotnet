using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Net60.FunctionApp.OutOfProc.IoC.Services;

namespace Net60.FunctionApp.OutOfProc.IoC
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