using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xunit;
using Moq;

using AGL.Base;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Core;

namespace BusinessTests
{
    public class OwnerRepositoryTests : BaseTests, IDisposable
    {
        public OwnerRepositoryTests()
        {
            
        }

        public override void Dispose()
        {
            base.Dispose();
        }


        [Fact] // (Skip = "To be mocked")]
        //[SkippableFact]
        [Trait("Category", "Business")]
        public async void OwnerRepositoryGet_RetrievePersonListMoq_True()
        {
            // Skip.If(true);

            // Arrange
            Mock<IURLHelper> _urlHelper = base.MoqURLHelper();
            IHttpClient _httpClient = await base.MockHttpClient();
            Mock<IDeserializer<Owner>> _deserializer = base.MoqDeserializerOwner();

            OwnerRepository<Owner> op = new OwnerRepository<Owner>(_urlHelper.Object,
                                                                   _httpClient,
                                                                   _deserializer.Object);

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


        [SkippableFact]
        [Trait("Category", "Business")]
        public async Task OwnerRepositoryGet_ConstructorNullsThrowBubbleException_True()
        {
            Skip.If(false);

            // Arrange
            IURLHelper _urlHelper = null;
            IHttpClient _httpClient = null;
            IDeserializer<Owner> _deserializer = null;

            OwnerRepository<Owner> op = new OwnerRepository<Owner>(_urlHelper,
                                                                   _httpClient,
                                                                   _deserializer);

            await Assert.ThrowsAsync<NullReferenceException>(() => op.GetAll());
        }


    }
}
