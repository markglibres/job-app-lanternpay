using System.IO;

namespace Lantern.File.Services
{
    public class FileStreamReader : IStreamReader
    {
        public Stream GetStream(string filename)
        {
            return new FileStream(filename, FileMode.Open);
        }
    }
}