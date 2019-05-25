using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Lantern.File.Services;
using Moq;
using Xunit;

namespace Lantern.File.Tests
{
    public class FileServiceTests
    {
        private FileService _fileService;
        private Mock<IFileReader> _fileReader;
        private Mock<IFileWriter> _fileWriter;
        private Mock<IStreamService> _streamService;

        public FileServiceTests()
        {
            _fileReader = new Mock<IFileReader>();
            _fileWriter = new Mock<IFileWriter>();
            _streamService = new Mock<IStreamService>();
            _fileService = new FileService(
                _fileReader.Object,
                _fileWriter.Object,
                _streamService.Object);
        }
        
        [Theory]
        [MemberData(nameof(GetFileContentsToReverseTest))]
        public void Should_Revers_File_Contents(List<string> content, List<string> expectedOutput)
        {

            // Arrange
            _fileReader.Setup(_ => _.ReadAllLines(It.IsAny<string>()))
                .Returns(content);
            
            // Act
            var result = _fileService
                .Reverse("test")
                .ToList();
                
            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == expectedOutput.Count);

            for (var i = 0; i < result.Count(); i++)
            {
                Assert.True(expectedOutput[i].Equals(result[i]));
            }
        }

        [Theory]
        [MemberData(nameof(GetFileContentsToWriteTest))]
        public void Should_Write_List_To_File(List<string> listContent, bool fileExists)
        {
            var filename = "test.txt";

            _fileReader.Setup(_ => _.Exists(It.IsAny<string>()))
                .Returns(fileExists);
            
            _streamService.Setup(_ => _.GetStreamFromList(It.IsAny<IEnumerable<string>>()))
                .Returns(new MemoryStream());
            _fileWriter.Setup(_ => _.WriteToFile(It.IsAny<string>(), It.IsAny<Stream>()))
                .Verifiable("fail to write to file");
            
            // Act
            var result = _fileService.WriteToFile(filename, listContent);
            
            // Assert
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrWhiteSpace(result));
            Assert.EndsWith(".txt",result);
            
            if(fileExists) Assert.NotEqual(filename, result);
            else Assert.Equal(filename, result);
                
            _fileWriter.Verify(_ => _.WriteToFile(It.IsAny<string>(), It.IsAny<Stream>()), Times.Once);
            
        }

        public static List<object[]> GetFileContentsToWriteTest()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<string>
                    {
                        "adidas"
                    }, 
                    true
                },
                new object[]
                {
                    new List<string>
                    {
                        "adidas"
                    }, 
                    false
                }
            };
        }

        public static List<object[]> GetFileContentsToReverseTest()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<string>
                    {
                        "adidas"
                    },
                    new List<string>
                    {
                        "sadida"
                    }, 
                },
                new object[]
                {
                    new List<string>(),
                    new List<string>()
                },
                new object[]
                {
                    new List<string>
                    {
                        "123 456",
                        "7890",
                        "111213"
                    },
                    new List<string>
                    {
                        "312111",
                        "0987",
                        "654 321"
                    }
                }
            };
        }
    }

    

    

    
}
