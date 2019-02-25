using Xunit;

using AGL.DeveloperTest.Models;

namespace ModelsTests
{
    public class OwnerTests
    {
        const string FIRST = "George";
        const string LAST = "Pagotelis";

        const string NAME = "George";
        const string FULLNAME = "George Pagotelis";

        const int TestAge = 18;


        [Theory]
        [InlineData(NAME, "Male", NAME)]
        [InlineData("George Pagotelis", "Male", "George Pagotelis")]
        [Trait("Category", "Models")]
        public void CreateOwner_CanCreate_True(string name,
                                               string gender,
                                               string expected)
                                                
        {
            // Arrange
            Owner _owner = null;

            // Act
            _owner = new Owner(name, gender);

            // Assert
            Assert.Equal(expected, _owner.Name);
        }


        [Theory]
        [InlineData("George", "", "Male", "George")]
        [InlineData("George", "Pagotelis", "Male", "George Pagotelis")]
        [InlineData(FIRST, LAST, "Female", FULLNAME)]
        [Trait("Category", "Models")]
        public void OwnerFullName_CanGet_True(string firstName,
                                              string lastName,
                                               string gender,
                                               string expected)
        {
            // Arrange
            Owner _owner = null;

            // Act
            _owner = new Owner(firstName, lastName, gender);

            // Assert
            Assert.Equal(expected, _owner.Name);
        }

    }









}
