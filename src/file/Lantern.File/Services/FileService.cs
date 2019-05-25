using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lantern.File.Services
{
    public class FileService : IFileService
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly IStreamService _streamService;

        public FileService(
            IFileReader fileReader,
            IFileWriter fileWriter,
            IStreamService streamService)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _streamService = streamService;
        }
        
        public IEnumerable<string> Reverse(string filename)
        {
            var reversedLine = _fileReader
                .ReadAllLines(filename)
                ?.Select(_ => string.Concat(_.Reverse()))
                .Reverse();
            
            return reversedLine;
        }

        public string WriteToFile(string filename, List<string> listContent)
        {
            var pathToWrite = filename;

            if (_fileReader.Exists(pathToWrite))
            {
                var ext = Path.GetExtension(pathToWrite);
                var file = Path.GetFileNameWithoutExtension(pathToWrite);
                pathToWrite = $"{file}_{DateTime.Now.Ticks.ToString()}{ext}";
            }

            using (var streamToWrite = _streamService.GetStreamFromList(listContent))
            {
                _fileWriter.WriteToFile(pathToWrite, streamToWrite);
            }

            return pathToWrite;

        }
    }
}