using System.IO;
using System;

namespace Classes
{
    public class Storage
    {
        private Logger _logger;

        public Storage(Logger logger) 
        {
            _logger = logger;
        }

        public void Store(string fileName, string dir, string content)
        {
            try {
                var path2 = Path.Combine(new string[] { 
                    Directory.GetCurrentDirectory(),
                    "storage",
                    dir
                });

                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }

                using var fileStream = new StreamWriter(Path.Combine(path2, fileName));
                fileStream.Write(content);
            } catch(Exception e) {
                _logger.Create(e.ToString());
            }
        }
    }
}