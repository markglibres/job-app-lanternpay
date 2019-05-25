using System.Collections.Generic;
using System.IO;

namespace Lantern.File.Services
{
    public interface IStreamService
    {
        Stream GetStreamFromFile(string filename);
        Stream GetStreamFromList(IEnumerable<string> list);
    }
}