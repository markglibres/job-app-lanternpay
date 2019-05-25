using System.Collections.Generic;

namespace Lantern.File.Services
{
    public interface IFileReader
    {
        IEnumerable<string> ReadAllLines(string filename);
    }
}