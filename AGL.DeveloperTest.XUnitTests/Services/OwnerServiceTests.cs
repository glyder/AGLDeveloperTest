using System.Threading.Tasks;
using System.Collections.Generic;

using Moq;
using Xunit;

using AGL.Base;
using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ServicesTests
{
    public class LinqSorterPetTests : BaseTests, IDisposable
    {
        #region Properties

        Mock<ILogger<OwnerService>> _loggerMock;
        Mock<IURLHelper> _urlHelper;
        IHttpClient _httpClientMock;
        Mock<IDeserializer<Owner>> _deserializer;
        ILinqSorterOwner _sortOwner;

        IOwnerRepository<Owner> _repositoryOwner; 
        
        #endregion

        #region "Constructor / Destructor / Setup"

        public LinqSorterPetTests()
        {
            OwnerServiceTestsAsync().GetAwaiter().GetResult();
        }

        async Task OwnerServiceTestsAsync()
        {
            _loggerMock = new Mock<ILogger<OwnerService>>();
            _urlHelper = base.MoqURLHelper();
            _httpClientMock = await base.MockHttpClient();
            _deserializer = base.MoqDeserializerOwner();
            _sortOwner = new LinqSorterOwner();

            _repositoryOwner = new OwnerRepository<Owner>(_urlHelper.Object,
                                                           _httpClientMock,
                                                           _deserializer.Object);
        }

        public override void Dispose()
        {
            base.Dispose();

            _urlHelper = null;
            _httpClientMock = null;
            _deserializer = null;
            _sortOwner = null;
            _repositoryOwner = null;
        }

        #endregion

        [Fact]
        [Trait("Category", "Services")]
        public async Task OwnerService_RetrieveAllList_True()
        {
            // Arrange
            // See Constructor/Setup above

            IOwnerService ownerService = new OwnerService(_loggerMock.Object,
                                                           _urlHelper.Object,
                                                          _httpClientMock,
                                                          _deserializer.Object,
                                                          _repositoryOwner,
                                                          _sortOwner);

            // Act
            var list = await ownerService.GetAll();

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Count > 0);
            Assert.NotNull(list[0]);
            Assert.NotNull(list[1]);

            Assert.Equal("Female", list[0].Key);
            Assert.Equal("Male", list[1].Key);

            Assert.Equal(3, list[0].Count());
            Assert.Equal(2, list[1].Count());

        }

        [Fact] // (Skip = "Need to fix LInQ query")]
        [Trait("Category", "Services")]
        public async Task OwnerService_RetrieveMaleList_True()
        {
            // Arrange
            // See Constructor/Setup above

            IOwnerService ownerService = new OwnerService(_loggerMock.Object,
                                                          _urlHelper.Object,
                                                          _httpClientMock,
                                                          _deserializer.Object,
                                                          _repositoryOwner,
                                                          _sortOwner);

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
        [Trait("Category", "Services")]
        public async Task OwnerService_RetrieveMaleListSorted_True()
        {
            // Arrange
            // See Constructor/Setup above

            IOwnerService ownerService = new OwnerService(_loggerMock.Object,
                                                          _urlHelper.Object,
                                                          _httpClientMock,
                                                          _deserializer.Object,
                                                          _repositoryOwner,
                                                          _sortOwner);


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
        [Trait("Category", "Services")]
        public async Task OwnerService_RetrieveUknownGenderIsNull_True()
        {
            // Arrange
            // See Constructor/Setup above

            IOwnerService ownerService = new OwnerService(_loggerMock.Object,
                                                          _urlHelper.Object,
                                                          _httpClientMock,
                                                          _deserializer.Object,
                                                          _repositoryOwner,
                                                          _sortOwner);

            // Act
            IList<Owner> list = await ownerService.GetByGender("Unknown", true);

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Count == 0);
        }

    }
}
