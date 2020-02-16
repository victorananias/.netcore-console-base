using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Settings
{
    public class Example1
    {
        public string Test { get; set; }
    }

    public class LoggingSettings
    {
        public string Path { get; set; }
    }

    public class AppSettings
    {
        public Example1 Example1 { get; set; }
        public LoggingSettings LoggingSettings { get; set; }
    }
}
