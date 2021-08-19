using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using Net60.FunctionApp.InProc.IoC.Services;

[assembly: FunctionsStartup(typeof(Net60.FunctionApp.InProc.IoC.StartUp))]
namespace Net60.FunctionApp.InProc.IoC
{
    /// <summary>
    /// This represents the entity to be invoked during the runtime startup.
    /// </summary>
    public class StartUp : FunctionsStartup
    {
        /// <inheritdoc />
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IMyService, MyService>();
        }
    }
}
