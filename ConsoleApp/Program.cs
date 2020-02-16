using System;
using System.IO;
using System.Threading.Tasks;
using ConsoleApp.Installers;
using ConsoleApp.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.InstallServicesAssembly(hostContext.Configuration);
                    services.Configure<AppSettings>(hostContext.Configuration);
                    services.AddHostedService<DefaultHostedService>();
                });
    }
}