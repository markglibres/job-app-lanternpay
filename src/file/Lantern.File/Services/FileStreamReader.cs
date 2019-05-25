using System.IO;

namespace Lantern.File.Services
{
    public class FileStreamReader : IFileStreamReader
    {
        public Stream GetStream(string filename)
        {
            return new FileStream(filename, FileMode.Open);
        }
    }
}