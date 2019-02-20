using System.Collections.Generic;
using Xunit;

using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Models;

namespace BusinessTests
{
    public class OwnerRepositoryTests
    {
        // [Fact(Skip = "To be mocked")]
        [SkippableFact]

        [Trait("Category", "Internet")]
        [Trait("Category", "Business")]
        public async void OwnerRepositoryGet_RetrievePersonListLive_True()
        {
            Skip.If(true);

            // Arrange
            OwnerRepository op = new OwnerRepository();

            // Act
            IList<Owner> list = await op.GetAll();

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Count > 0);
            Assert.NotNull(list[0]);

            Assert.Equal("Bob", list[0].Name);
            Assert.Equal("Male", list[0].Gender);
            Assert.Equal(23, list[0].Age);

            Assert.Equal(2, list[0].Pets.Count);
            Assert.Equal("Garfield", list[0].Pets[0].Name);
            Assert.Equal("Cat", list[0].Pets[0].Type);
        }

    }
}
