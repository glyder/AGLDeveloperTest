using Xunit;

using AGL.DeveloperTest.Models;

namespace ModelsTests
{
    public class PetsTests
    {
        #region "Properties"

        const string NAME = "Garfield";
        const string TYPE = "Cat";


        #endregion

        [Theory]
        [InlineData(NAME, TYPE, NAME)]
        [Trait("Category", "Models")]
        public void CreatePets_CanCreate_True(string name,
                                               string type,
                                               string expected)

        {
            // Arrange
            Pets pet = null;

            // Act
            pet = new Pets(name, type);

            // Assert
            Assert.Equal(expected, pet.Name);
        }

    }
}
