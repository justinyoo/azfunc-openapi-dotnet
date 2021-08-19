using Net60.FunctionApp.OutOfProc.IoC.Models;

namespace Net60.FunctionApp.OutOfProc.IoC.Services
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