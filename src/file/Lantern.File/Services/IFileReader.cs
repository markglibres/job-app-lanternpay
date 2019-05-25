using System.Collections.Generic;
using System.IO;

namespace Lantern.File.Services
{
    public interface IFileReader
    {
        IEnumerable<string> ReadAllLines(string filename);
    }
}