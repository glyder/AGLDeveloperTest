﻿using System;
using System.Linq;
using System.Threading.Tasks;

using Moq;
using Xunit;

using AGL.Base;
using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;


namespace BusinessTests
{
    public class LinqSorterPetTests : BaseTests, IDisposable
    {
        // Mock<ILogger<OwnerService>> _loggerMock = new Mock<ILogger<OwnerService>>();
        Mock<AbstractLogger<OwnerService>> _loggerMock = new Mock<AbstractLogger<OwnerService>>(); 
        
        Mock<IURLHelper> _urlHelper;
        IHttpClient _httpClientMock;
        Mock<IDeserializer<Owner>> _deserializer;
        ILinqSorterOwner _sortOwner;

        IOwnerRepository<Owner> _repositoryOwner;

        #region "Constructor / Destructor / Setup"

        public LinqSorterPetTests()
        {
            LinqSorterPetTestsAsync().GetAwaiter().GetResult();
        }

        async Task LinqSorterPetTestsAsync()
        {
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
        [Trait("Category", "Business")]
        public async Task OwnereListByGender_SortFemalePets_True()
        {
            // Arrange
            // See Constructor/Setup above

            IOwnerService ownerService = new OwnerService(_loggerMock.Object,
                                                          _urlHelper.Object,
                                                          _httpClientMock,
                                                          _deserializer.Object,
                                                          _repositoryOwner,
                                                          _sortOwner);
            var listGenderSorted = await ownerService.GetAll();

            // Act
            var ownerGroupByGender = _sortOwner.SortGroupByPetType(listGenderSorted[0]);

            // Assert
            foreach (var pet in ownerGroupByGender)
            {
                Assert.Equal("Cat", pet.Type);
            }
        }


        [Fact]
        [Trait("Category", "Business")]
        public async Task OwnereListByGender_SortMalePets_True()
        {
            // Arrange
            // See Constructor/Setup above

            IOwnerService ownerService = new OwnerService(_loggerMock.Object,
                                                          _urlHelper.Object,
                                                          _httpClientMock,
                                                          _deserializer.Object,
                                                          _repositoryOwner,
                                                          _sortOwner);
            var listGenderSorted = await ownerService.GetAll();

            // Act
            var ownerGroupByGender = _sortOwner.SortGroupByPetType(listGenderSorted[1]);

            // Assert
            foreach (var pet in ownerGroupByGender)
            {
                Assert.Equal("Cat", pet.Type);
            }
        }

        [Fact]
        [Trait("Category", "Business")]
        public async Task OwnereListByGender_SortFemalePetsOrderName_True()
        {
            // Arrange
            // See Constructor/Setup above

            IOwnerService ownerService = new OwnerService(_loggerMock.Object,
                                                          _urlHelper.Object,
                                                          _httpClientMock,
                                                          _deserializer.Object,
                                                          _repositoryOwner,
                                                          _sortOwner);
            var listGenderSorted = await ownerService.GetAll();

            // Act
            var ownerGroupByGender = _sortOwner.SortGroupByPetType(listGenderSorted[0]);

            // Assert
            foreach (var pet in ownerGroupByGender)
            {
                Assert.Equal("Cat", pet.Type);
            }

            var femalePetFirst = ownerGroupByGender.First();
            var femalePetSecond = ownerGroupByGender.Skip(1).First();
            var femalePetThird = ownerGroupByGender.Skip(2).First();

            Assert.Equal("Garfield", femalePetFirst.Name);
            Assert.Equal("Simba", femalePetSecond.Name);
            Assert.Equal("Tabby", femalePetThird.Name);
        }

        [Fact]
        [Trait("Category", "Business")]
        public async Task OwnereListByGender_SortMalePetsOrderName_True()
        {
            // Arrange
            // See Constructor/Setup above

            IOwnerService ownerService = new OwnerService(_loggerMock.Object,
                                                          _urlHelper.Object,
                                                          _httpClientMock,
                                                          _deserializer.Object,
                                                          _repositoryOwner,
                                                          _sortOwner);
            var listGenderSorted = await ownerService.GetAll();

            // Act
            var ownerGroupByGender = _sortOwner.SortGroupByPetType(listGenderSorted[1]);

            // Assert
            foreach (var pet in ownerGroupByGender)
            {
                Assert.Equal("Cat", pet.Type);
            }

            var malePetFirst = ownerGroupByGender.First();
            var malePetSecond = ownerGroupByGender.Skip(1).First();

            Assert.Equal("Garfield", malePetFirst.Name);
            Assert.Equal("Jim", malePetSecond.Name);
        }

    }
}
