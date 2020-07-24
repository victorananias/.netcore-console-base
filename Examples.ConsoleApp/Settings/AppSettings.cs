using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.ConsoleApp.Settings
{
    public class Example1
    {
        public string Test { get; set; }
    }

    public class AppSettings
    {
        public Example1 Example1 { get; set; }
    }
}
