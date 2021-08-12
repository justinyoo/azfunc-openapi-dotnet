using System.Threading.Tasks;

using NetCoreApp31.FunctionApp.IoC.Models;

namespace NetCoreApp31.FunctionApp.IoC.Services
{
    public interface IMyService
    {
        Task<Greeting> GreetAsync(string name);
    }

    public class MyService : IMyService
    {
        public async Task<Greeting> GreetAsync(string name)
        {
            var greeting = new Greeting { Message = $"Hello, {name}!" };

            return await Task.FromResult(greeting).ConfigureAwait(false);
        }
    }
}