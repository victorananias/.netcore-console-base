using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;


namespace ConsoleApp.Services
{
    public class MainService : IMainService
    {
        private IHostApplicationLifetime _appLifetime;

        public MainService(IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
        }

        public async Task Run()
        {
            Console.WriteLine("Hello World");
            _appLifetime.StopApplication();
        }
    }
}