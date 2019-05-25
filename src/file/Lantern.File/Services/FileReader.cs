using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Lantern.File.Services
{
    public class FileReader : IFileReader
    {
        private readonly IStreamReader _streamReader;

        public FileReader(IStreamReader streamReader)
        {
            _streamReader = streamReader;
        }
        
        public IEnumerable<string> ReadAllLines(string filename)
        {
            var fileContents = new List<string>();
            using (var streamReader = new StreamReader(_streamReader.GetStream(filename)))
            {
                while (streamReader.Peek() >= 0)
                {
                    fileContents.Add(streamReader.ReadLine());
                }
            }

            return fileContents;
        }
    }
}