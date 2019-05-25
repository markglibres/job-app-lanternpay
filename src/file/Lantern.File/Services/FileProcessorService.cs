using System.Collections.Generic;
using System.Linq;

namespace Lantern.File.Services
{
    public class FileProcessorService : IFileProcessorService
    {
        private readonly IFileReader _fileReader;

        public FileProcessorService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        
        public IEnumerable<string> Reverse(string filename)
        {
            var reversedLine = _fileReader
                .ReadAllLines(filename)
                ?.Select(_ => string.Concat(_.Reverse()))
                .Reverse();
            
            
            return reversedLine;
        }
    }
}