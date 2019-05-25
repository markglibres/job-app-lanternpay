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
    public class FileProcessorTests
    {
        private FileProcessorService _fileProcessorService;
        private Mock<IFileReader> _fileReader;

        public FileProcessorTests()
        {
            _fileReader = new Mock<IFileReader>();
            _fileProcessorService = new FileProcessorService(
                _fileReader.Object);
        }
        
        [Theory]
        [MemberData(nameof(GetFileContentsTest))]
        public void Should_Revers_File_Contents(List<string> content, List<string> expectedOutput)
        {

            // Arrange
            _fileReader.Setup(_ => _.ReadAllLines(It.IsAny<string>()))
                .Returns(content);
            
            // Act
            var result = _fileProcessorService
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

        public static List<object[]> GetFileContentsTest()
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
