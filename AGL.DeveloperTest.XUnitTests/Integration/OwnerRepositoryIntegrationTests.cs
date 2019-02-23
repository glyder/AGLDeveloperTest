using System;
using System.Threading.Tasks;

using Xunit;

using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Core;

namespace IntegrationTests
{
    public class OwnerServiceTests
    {
        // [Fact(Skip = "To be mocked")]
        [SkippableFact]
        [Trait("Category", "Internet")]
        [Trait("Category", "Integration")]
        public async Task OwnerRepositoryGet_ConstructorNullsThrowBubbleException_True()
        {
            Skip.If(false);

            // Arrange
            IURLHelper _urlHelper = null;
            IHttpClient _httpClient = null;
            IDeserializer<Owner> _deserializer = null;

            OwnerRepository op = new OwnerRepository(_urlHelper,
                                                     _httpClient,
                                                     _deserializer);

            await Assert.ThrowsAsync<NullReferenceException>(() => op.GetAll());

            //// Act
            //// TODO: MOQ here
            //IList<Owner> list = await op.GetAll();

            //// Assert
            //Assert.NotNull(list);
            //Assert.True(list.Count > 0);
            //Assert.NotNull(list[0]);

            //Assert.Equal("Bob", list[0].Name);
            //Assert.Equal("Male", list[0].Gender);
            //Assert.Equal(23, list[0].Age);

            //Assert.Equal(2, list[0].Pets.Count);
            //Assert.Equal("Garfield", list[0].Pets[0].Name);
            //Assert.Equal("Cat", list[0].Pets[0].Type);
        }

        // [Fact(Skip = "To be mocked")]
        [SkippableFact]
        [Trait("Category", "Internet")]
        [Trait("Category", "Integration")]
        public async Task OwnerRepositoryGet_RetrievePersonListMOQ_True()
        {
            Skip.If(false);

            // Arrange
            IURLHelper _urlHelper = null;
            IHttpClient _httpClient = null;
            IDeserializer<Owner> _deserializer = null;

            OwnerRepository op = new OwnerRepository(_urlHelper,
                                                     _httpClient,
                                                     _deserializer);

            await Assert.ThrowsAsync<NullReferenceException>(() => op.GetAll());

            //// Act
            //// TODO: MOQ here
            //IList<Owner> list = await op.GetAll();

            //// Assert
            //Assert.NotNull(list);
            //Assert.True(list.Count > 0);
            //Assert.NotNull(list[0]);

            //Assert.Equal("Bob", list[0].Name);
            //Assert.Equal("Male", list[0].Gender);
            //Assert.Equal(23, list[0].Age);

            //Assert.Equal(2, list[0].Pets.Count);
            //Assert.Equal("Garfield", list[0].Pets[0].Name);
            //Assert.Equal("Cat", list[0].Pets[0].Type);
        }
    }
}
