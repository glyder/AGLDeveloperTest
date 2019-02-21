using Xunit;

using AGL.Base;
using AGL.DeveloperTest.Core;

namespace CoreTests
{
    public class FileHelperTests : BaseTests
    {
        [Fact]
        [Trait("Category", "TestHelper")]
        public void JSONPeopleSampleData_CanBeRead_True()
        {
            // Arrange
            string fileText = "";

            // Act
            fileText = base.helperGetSONFromFile(PEOPLE_FILE_JSON);

            // Assert
            Assert.NotEmpty(fileText);
            Assert.Contains("name", fileText);
            Assert.Contains("pets", fileText);
        }

        [Fact]
        [Trait("Category", "Core")]
        public void FileReader_CanBeRead_True()
        {
            // Arrange
            string fileText = "";
            IFileReader fileReader = new FileHelper();

            // Act
            fileText = fileReader.Get(PEOPLE_FILE_JSON);

            // Assert
            Assert.NotEmpty(fileText);
            Assert.Contains("name", fileText);
            Assert.Contains("pets", fileText);
        }
    }
}
