using System.Collections.Generic;

namespace Lantern.File.Services
{
    public interface IFileProcessorService
    {
        IEnumerable<string> Reverse(string filename);
    }
}