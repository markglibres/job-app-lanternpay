using System;
using System.IO;
using Lantern.File.Services;

namespace Lantern.File
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStreamReader = new FileStreamReader();
            var fileReader = new FileReader(fileStreamReader);
            var fileProcessor = new FileProcessorService(fileReader);

            var result = fileProcessor.Reverse("fileToReverse.txt");
            
            Console.WriteLine(string.Join("\r\n", result));

        }
    }
}
