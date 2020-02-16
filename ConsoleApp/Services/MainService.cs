using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;


namespace ConsoleApp.Services
{
    public class MainService : IMainService
    {
        private IHostApplicationLifetime _appLifetime;
        private ILogger<MainService> _logger;

        public MainService(IHostApplicationLifetime appLifetime, ILogger<MainService> logger)
        {
            _appLifetime = appLifetime;
            _logger = logger;
        }

        public async Task Run()
        {
            _logger.LogInformation("Hello World.");
            _appLifetime.StopApplication();
        }
    }
}