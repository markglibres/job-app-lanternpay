using System.IO;

namespace Lantern.File.Services
{
    public interface IFileStreamReader
    {
        Stream GetStream(string filename);
    }
}