using System;
using System.Linq;
using System.Collections.Generic;

using Xunit;
using Moq;

using AGL.Base;
using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Core;
using System.Threading.Tasks;

namespace CoreTests
{
    public class LinqSorterOwnerTests : BaseTests, IDisposable
    {
        Mock<IURLHelper> _urlHelper = null;
        IHttpClient _httpClient = null;
        Mock<IDeserializer<Owner>> _deserializer = null;

        OwnerRepository<Owner> _ownerRepository = null;

        public LinqSorterOwnerTests()
        {
            LinqSorterOwnerTestsAsync().GetAwaiter().GetResult();
        }

        async Task LinqSorterOwnerTestsAsync()
        {
            _urlHelper = base.MoqURLHelper();
            _httpClient = await base.MockHttpClient();
            _deserializer = base.MoqDeserializerOwner();
            _ownerRepository = new OwnerRepository<Owner>(_urlHelper.Object,
                                                           _httpClient,
                                                           _deserializer.Object);
        }

        public override void Dispose()
        {
            base.Dispose();
        }


        [Fact]
        [Trait("Category", "Core")]
        public async void ListOwner_SortGetGenderKeys_True()
        {
            // Arrange
            // See Constructor/Setup above

            IList<Owner> listOwner = await _ownerRepository.GetAll();
            ILinqSorterOwner linqSorter = new LinqSorterOwner();

            // Act
            var listSorted = linqSorter.SortGroupByGender(listOwner);

            // Assert
            Assert.Equal(2, listSorted.Count);
            Assert.Equal("Female", listSorted[0].Key);
            Assert.Equal("Male", listSorted[1].Key);
        }


        [Fact]
        [Trait("Category", "Core")]
        public async void ListOwnerSort_SortByGenderFemaleAliceFirst_True()
        {
            // Arrange
            // See Constructor/Setup above

            IList<Owner> listOwner = await _ownerRepository.GetAll();
            ILinqSorterOwner linqSorter = new LinqSorterOwner();

            // Act
            var listSorted = linqSorter.SortGroupByGender(listOwner);

            // Assert
            var female = listSorted[0];
            var femaleFirst = female.First();
            Assert.Equal("Alice", femaleFirst.Name);
        }

        [Fact]
        [Trait("Category", "Core")]
        public async void ListOwnerSort_SortByGenderFemalesInOrder_True()
        {
            // Arrange
            // See Constructor/Setup above

            IList<Owner> listOwner = await _ownerRepository.GetAll();
            ILinqSorterOwner linqSorter = new LinqSorterOwner();

            // Act
            var listSorted = linqSorter.SortGroupByGender(listOwner);

            // Assert
            var female = listSorted[0];
            var femaleFirst = female.First();
            var femaleSecond = female.Skip(1).First();
            var femaleThird = female.Skip(2).First();

            Assert.Equal("Alice", femaleFirst.Name);
            Assert.Equal("Jennifer", femaleSecond.Name);
            Assert.Equal("Samantha", femaleThird.Name);
        }

        [Fact]
        [Trait("Category", "Core")]
        public async void ListOwnerSort_SortByGenderMalesInOrder_True()
        {
            // Arrange
            // See Constructor/Setup above

            IList<Owner> listOwner = await _ownerRepository.GetAll();
            ILinqSorterOwner linqSorter = new LinqSorterOwner();

            // Act
            var listSorted = linqSorter.SortGroupByGender(listOwner);

            // Assert
            var male = listSorted[1];
            var maleFirst = male.First();
            var maleSecond = male.Skip(1).First();

            Assert.Equal("Bob", maleFirst.Name);
            Assert.Equal("Fred", maleSecond.Name);
        }
    }
}
