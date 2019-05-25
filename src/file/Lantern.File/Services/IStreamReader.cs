using System.Collections.Generic;
using System.IO;

namespace Lantern.File.Services
{
    public interface IStreamReader
    {
        Stream GetStream(string filename);
    }
}