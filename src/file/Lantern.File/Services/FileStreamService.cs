using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lantern.File.Services
{
    public class FileStreamService : IStreamService
    {
        public Stream GetStreamFromFile(string filename)
        {
            return new FileStream(filename, FileMode.Open);
        }

        public Stream GetStreamFromList(IEnumerable<string> list)
        {
            if(!list?.Any() ?? true) return new MemoryStream();

            var content = string.Join(
                "\r\n",
                list);
            
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            return stream;

        }
    }
}