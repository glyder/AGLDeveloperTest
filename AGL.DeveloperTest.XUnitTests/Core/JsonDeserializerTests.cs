using System.Collections.Generic;
using Xunit;

using AGL.Base;
using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Core;

namespace CoreTests
{
    public class JsonDeserializerTests : BaseCoreTests
    {
        [Fact]
        [Trait("Category", "Core")]
        public void JsonDeserializer_ConvertStringToPerson_True()
        {
            // Arrange
            string fileText = base.helperGetSONFromFile(PEOPLE_FILE_JSON);
            IDeserializer<Owner> serializer = new JsonDeserializer<Owner>();

            // Act
            IList<Owner> resultOwner = serializer.DeserializeText(fileText);

            // Assert
            Assert.NotNull(resultOwner);
            Assert.True(resultOwner.Count > 0);
        }

        [Fact]
        [Trait("Category", "Core")]
        public void JsonDeserializer_PersonJSONParametersMappedCorrectly_True()
        {
            // Arrange
            string fileText = base.helperGetSONFromFile(PEOPLE_FILE_JSON);
            IDeserializer<Owner> serializer = new JsonDeserializer<Owner>();

            // Act
            IList<Owner> resultOwner = serializer.DeserializeText(fileText);

            // Assert
            Assert.NotNull(resultOwner);
            Assert.True(resultOwner.Count > 0);
            Assert.NotNull(resultOwner[0]);

            Assert.Equal("Bob", resultOwner[0].Name);
            Assert.Equal("Male", resultOwner[0].Gender);
            Assert.Equal(23, resultOwner[0].Age);

            Assert.Equal(2, resultOwner[0].Pets.Count);
            Assert.Equal("Garfield", resultOwner[0].Pets[0].Name);
            Assert.Equal("Cat", resultOwner[0].Pets[0].Type);

        }

    }
}
