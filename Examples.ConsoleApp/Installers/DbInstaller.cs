using Examples.ConsoleApp.Installers;
// using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Examples.ConsoleApp.Installers
{
    public class DbInstaller
    {
        
        private static readonly ILoggerFactory _dbLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // var connection = configuration.GetConnectionString("DefaultConnection");

            // services.AddDbContext<DbContext>(options =>
            // {
            //     options.UseLoggerFactory(_dbLoggerFactory).UseSqlServer(connection);
            // });
        }
    }
}