using System.Threading.Tasks;

using Xunit;

using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Services;
using System.Collections.Generic;

namespace ServicesTests
{
    public class OwnerServiceTests
    {       

        [Fact]
        [Trait("Category", "Internet")]
        [Trait("Category", "Services")]
        public async Task OwnerService_RetrieveMaleList_True()
        {
            // Arrange
            IOwnerService ownerService = new OwnerService();

            // Act
            IList<Owner> list = await ownerService.GetByGender("Male", true);

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Count > 0);
            Assert.NotNull(list[0]);

            Assert.Equal("Male", list[0].Gender);
            Assert.Equal("Male", list[1].Gender);

            Assert.Equal("Bob", list[0].Name);
        }

        [Fact]
        [Trait("Category", "Internet")]
        [Trait("Category", "Services")]
        public async Task OwnerService_RetrieveMaleListSorted_True()
        {
            // Arrange
            IOwnerService ownerService = new OwnerService();

            // Act
            IList<Owner> list = await ownerService.GetByGender("Female", true);

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Count > 0);
            Assert.NotNull(list[0]);

            Assert.Equal("Female", list[0].Gender);
            Assert.Equal("Female", list[2].Gender);

            Assert.Equal("Alice", list[0].Name);
        }


        [Fact]
        [Trait("Category", "Internet")]
        [Trait("Category", "Services")]
        public async Task OwnerService_RetrieveUknownGenderIsNull_True()
        {
            // Arrange
            IOwnerService ownerService = new OwnerService();

            // Act
            IList<Owner> list = await ownerService.GetByGender("Unknown", true);

            // Assert
            Assert.Null(list);
        }


    }
}
