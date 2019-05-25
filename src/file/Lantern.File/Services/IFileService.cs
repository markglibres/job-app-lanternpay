using System.Collections.Generic;
using System.IO;

namespace Lantern.File.Services
{
    public interface IFileService
    {
        IEnumerable<string> Reverse(string filename);
        string WriteToFile(string filename, List<string> listContent);
    }
}