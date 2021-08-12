using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using NetCoreApp31.FunctionApp.IoC.Services;

[assembly: FunctionsStartup(typeof(NetCoreApp31.FunctionApp.IoC.StartUp))]
namespace NetCoreApp31.FunctionApp.IoC
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
