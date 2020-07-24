using System.Threading;
using System.Threading.Tasks;
using Examples.ConsoleApp.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Examples.ConsoleApp
{
    public class DefaultHostedService : IHostedService
    {
        private IMainService _service;
        private ILogger<DefaultHostedService> _logger;

        public DefaultHostedService(
            IMainService service, ILogger<DefaultHostedService> logger)
        {
            _service = service;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Program Started.");
            _service.Run();
            return Task.CompletedTask;
        }
        
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Program Finished.");
            return Task.CompletedTask;
        }
    }
}