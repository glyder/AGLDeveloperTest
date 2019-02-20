using Xunit;

using AGL.DeveloperTest.Models;

namespace ModelsTests
{
    public class PetsTests
    {
        #region "Properties"

        const string FIRST = "George";
        const string LAST = "Pagotelis";

        const string NAME = "George";
        const string FULLNAME = "George Pagotelis";

        const int TestAge = 18;

        #endregion

        [Fact]
        [Trait("Category", "Models")]
        public void CreateOwner_CanCreate_True()
        {
            // Arrange
            Owner _owner = new Owner(NAME, GenderType.Male);

            // Act

            // Assert
            Assert.Equal(NAME, _owner.Name);
        }

        [Fact]
        [Trait("Category", "Models")]
        public void OwnerFullName_CanGet_True()
        {
            // Arrange
            Owner _owner = new Owner(FIRST, LAST, GenderType.Male);

            // Act

            // Assert
            Assert.Equal(FULLNAME, _owner.Name);
        }


        [Fact]
        [Trait("Category", "Models")]
        public void OwnerAge_SetGetAge_True()
        {
            //Arrange
            Owner _owner = new Owner(NAME, GenderType.Male);

            //Act
            _owner.Age = TestAge;

            //Assert
            Assert.Equal(TestAge, _owner.Age);
        }

    }
}
