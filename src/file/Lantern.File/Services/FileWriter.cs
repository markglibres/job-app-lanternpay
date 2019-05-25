using System.IO;

namespace Lantern.File.Services
{
    public class FileWriter : IFileWriter
    {
        public void WriteToFile(string filename, Stream stream)
        {
            using (var fileStream = System.IO.File.Create(filename))
            {
                stream.CopyTo(fileStream);
            }
            
        }
    }
}