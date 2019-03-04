using System.Collections.Generic;
using Xunit;

using AGL.Base;
using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Core;

namespace CoreTests
{
    public class DeserializerJsonTests : BaseTests
    {
        [Fact]
        [Trait("Category", "Core")]
        public void Deserialize_StringToListOwners_True()
        {
            // Arrange
            string fileText = base.helperGetJSONFromFile(PEOPLE_FILE_JSON);
            IDeserializer<Owner> serializer = new DeserializerJson<Owner>();

            // Act
            IList<Owner> resultOwner = serializer.DeserializeText(fileText);

            // Assert
            Assert.NotNull(resultOwner);
            Assert.True(resultOwner.Count > 0);
        }

        [Fact]
        [Trait("Category", "Core")]
        public void DeserializerJson_PersonJSONParametersMappedCorrectly_True()
        {
            // Arrange
            string fileText = base.helperGetJSONFromFile(PEOPLE_FILE_JSON);
            IDeserializer<Owner> serializer = new DeserializerJson<Owner>();

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
