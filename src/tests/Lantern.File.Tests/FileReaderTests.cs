using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lantern.File.Services;
using Moq;
using Xunit;

namespace Lantern.File.Tests
{
    public class FileReaderTests
    {
        private FileReader _fileReader;
        private Mock<IStreamReader> _fileStreamReader;

        public FileReaderTests()
        {
            _fileStreamReader = new Mock<IStreamReader>();
            _fileReader = new FileReader(_fileStreamReader.Object);
        }
        
        [Theory]
        [MemberData(nameof(FileContentsToRead))]
        public void Should_Read_File_Contents(string contents, List<string> expectedLines)
        {
            // Arrange
            var filename = "test.txt";
            _fileStreamReader.Setup(_ => _.GetStream(It.IsAny<string>()))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes(contents)));
            
            // Act
            var result = _fileReader
                .ReadAllLines(filename)
                .ToList();
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedLines.Count, result.Count);
            Assert.All(expectedLines, line => result.Contains(line));
        }

        public static List<object[]> FileContentsToRead()
        {
            return new List<object[]>
            {
                new object[]
                {
                    "",
                    new List<string>(), 
                },
                new object[]
                {
                    "this is the file content",
                    new List<string>
                    {
                        "this is the file content"
                    }, 
                },
                new object[]
                {
                    "this is the file content\r\ntest",
                    new List<string>
                    {
                        "this is the file content",
                        "test"
                    }, 
                }
            };
        }
        
    }
}