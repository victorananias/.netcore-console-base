using System.IO;
using System;
using System.Threading.Tasks;

namespace Classes
{
    public class Storage
    {
        private readonly string _directory;

        public Storage(string directory)
        {
            _directory = directory;
        }

        public void Store(string fileName, string dir, string content)
        {
            var path = Path.Combine(new[]
            {
                _directory,
                dir
            });

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using var fileStream = new StreamWriter(Path.Combine(path, fileName));
            fileStream.Write(content);
        }

        public string Read(string fileName, string dir)
        {
            var texto = "";

            var path = Path.Combine(new[]
            {
                _directory,
                dir,
                fileName
            });

            using var sr = new StreamReader(path);
            texto = sr.ReadToEnd();

            return texto;
        }
        
        public async Task<string> ReadAsync(string fullPath)
        {
            string texto;

            using var sr = new StreamReader(fullPath);
            texto = await sr.ReadToEndAsync();

            return texto;
        }
    }
}