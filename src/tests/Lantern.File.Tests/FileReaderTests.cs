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
        private Mock<IFileStreamReader> _fileStreamReader;

        public FileReaderTests()
        {
            _fileStreamReader = new Mock<IFileStreamReader>();
            _fileReader = new FileReader(_fileStreamReader.Object);
        }
        
        [Fact]
        public void Test()
        {
            // Arrange
            var filename = "test.txt";
            var content = "this is the file content";

            _fileStreamReader.Setup(_ => _.GetStream(It.IsAny<string>()))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes(content)));
            
            // Act
            var result = _fileReader
                .ReadAllLines(filename)
                .ToList();
            
            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            Assert.Equal(content, result.FirstOrDefault());
        }
    }
}