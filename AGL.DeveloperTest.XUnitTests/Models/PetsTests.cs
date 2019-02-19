using System;
using System.Linq;
using AGL.DeveloperTest.Models;
using Xunit;

namespace AGL.DeveloperTest.XUnitTests
{
    public class PetsTests
    {
        const string FIRST = "George";
        const string LAST = "Pagotelis";

        const string NAME = "George";
        const string FULLNAME = "George Pagotelis";

        const int TestAge = 18;

        [Fact]
        [Trait("Category", "Unit")]
        public void CreateOwner_CanCreate_True()
        {
            // Arrange
            Owner _owner = new Owner(NAME, Gender.Male);

            // Act

            // Assert
            Assert.Equal(NAME, _owner.Name);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void OwnerFullName_CanGet_True()
        {
            // Arrange
            Owner _owner = new Owner(FIRST, LAST, Gender.Male);

            // Act

            // Assert
            Assert.Equal(FULLNAME, _owner.Name);
        }


        [Fact]
        [Trait("Category", "Unit")]
        public void OwnerAge_SetGetAge_True()
        {
            //Arrange
            Owner _owner = new Owner(NAME, Gender.Male);

            //Act
            _owner.Age = TestAge;

            //Assert
            Assert.Equal(TestAge, _owner.Age);
        }


    }









}
