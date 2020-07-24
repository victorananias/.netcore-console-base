using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;


namespace Examples.ConsoleApp.Services
{
    public class MainService : IMainService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private ILogger<MainService> _logger;

        public MainService(IHostApplicationLifetime appLifetime, ILogger<MainService> logger)
        {
            _appLifetime = appLifetime;
            _logger = logger;
        }

        public async Task Run()
        {
            Console.WriteLine("Hello World");
            _appLifetime.StopApplication();
        }
    }
}