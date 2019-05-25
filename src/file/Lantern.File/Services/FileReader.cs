using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Lantern.File.Services
{
    public class FileReader : IFileReader
    {
        private readonly IStreamService _streamService;

        public FileReader(IStreamService streamService)
        {
            _streamService = streamService;
        }
        
        public IEnumerable<string> ReadAllLines(string filename)
        {
            var fileContents = new List<string>();
            using (var streamReader = new StreamReader(_streamService.GetStreamFromFile(filename)))
            {
                while (streamReader.Peek() >= 0)
                {
                    fileContents.Add(streamReader.ReadLine());
                }
            }

            return fileContents;
        }

        public bool Exists(string filename)
        {
            return System.IO.File.Exists(filename);
        }
    }
}