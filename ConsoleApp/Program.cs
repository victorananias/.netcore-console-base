using System;
using System.IO;
using System.Threading.Tasks;
using ConsoleApp.Installers;
using ConsoleApp.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            await serviceProvider.GetService<Main>().Run();
        }

        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var configuration = Configuration();

            services.AddSingleton<IConfiguration>(configuration);

            services.InstallServicesAssembly(configuration);

            services.AddTransient<Main>();

            services.AddOptions();

            services.Configure<AppSettings>(configuration);

            return services;
        }

        private static IConfiguration Configuration()
        {
            return (new ConfigurationBuilder())
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }
        
    }
}
