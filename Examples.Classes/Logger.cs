using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Examples.Classes
{
    public class Logger
    {
        private string _logsDirectory;
        private string _logFile;

        public Logger(IConfiguration _config)
        {
            _logsDirectory = string.IsNullOrEmpty(_config.GetSection("Logger")["Path"])
                ? "./logs"
                : _config.GetSection("Logger")["Path"];
            _logFile = _logsDirectory + "/" + DateTime.Now.ToString("yyyyMMdd");
        }

        public void Create(string log)
        {
            CheckLogsDirectory();

            Console.WriteLine(log);

            Insert(log);
        }

        private void Insert(string log)
        {
            using var fileStream = new StreamWriter(_logFile, true);
            fileStream.WriteLine("\n---" + DateTime.Now.ToString("HH:mm:ss") + "---");
            fileStream.WriteLine(log);
            fileStream.Close();
        }

        private void CheckLogsDirectory()
        {
            if (!Directory.Exists(_logsDirectory))
            {
                Directory.CreateDirectory(_logsDirectory);
            }
        }
    }
}