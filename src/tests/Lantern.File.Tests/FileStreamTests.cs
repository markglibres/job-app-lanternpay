using System.Collections.Generic;
using System.IO;
using Lantern.File.Services;
using Xunit;

namespace Lantern.File.Tests
{
    public class FileStreamTests
    {
        private FileStreamService _fileStreamService;

        public FileStreamTests()
        {
            _fileStreamService = new FileStreamService();
        }
        
        [Theory]
        [MemberData(nameof(GetListContentsToWrite))]
        public void Test(List<string> listContents)
        {
            // Act
            using (var streamReader = new StreamReader(_fileStreamService.GetStreamFromList(listContents)))
            {
                var line = 0;
                while (streamReader.Peek() >= 0)
                {
                    // Assert
                    Assert.Equal(listContents[line++], streamReader.ReadLine());
                }
            }
            
        }

        public static List<object[]> GetListContentsToWrite()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<string>()
                },
                new object[]
                {
                    new List<string>
                    {
                        "test"
                    }
                },
                new object[]
                {
                    new List<string>
                    {
                        "1",
                        "line 2",
                        "line 3"
                    }
                }
            };
        }
    }
}