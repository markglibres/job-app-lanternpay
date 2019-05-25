using System;
using System.IO;
using System.Linq;
using Lantern.File.Services;

namespace Lantern.File
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStreamReader = new FileStreamService();
            var fileReader = new FileReader(fileStreamReader);
            var fileWriter = new FileWriter();
            var streamService = new FileStreamService();
            
            var fileProcessor = new FileService(
                fileReader,
                fileWriter,
                streamService);

            var reversedContent = fileProcessor
                .Reverse("input.txt")
                .ToList();

            var filename = fileProcessor.WriteToFile("output.txt", reversedContent);
            Console.WriteLine($"File content reversed and save to: {filename}");
            

        }
    }
}
