using System.IO;

namespace Lantern.File.Services
{
    public interface IFileWriter
    {
        void WriteToFile(string filename, Stream stream);
    }
}