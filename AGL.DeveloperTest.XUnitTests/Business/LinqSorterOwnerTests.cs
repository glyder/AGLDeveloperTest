using System;
using System.Linq;
using System.Collections.Generic;

using Xunit;

using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Business;

namespace CoreTests
{
    public class LinqSorterOwnerTests : IDisposable
    {
        public void Dispose()
        {

        }

        [Fact]
        [Trait("Category", "Core")]
        public async void ListOwner_SortGetGenderKeys_True()
        {
            // Arrange
            OwnerRepository op = new OwnerRepository();
            IList<Owner> list = await op.GetAll();
            ILinqSorterOwner<Owner> linqSorter = new LinqSorterOwner<Owner>();

            // Act
            var listSorted = linqSorter.SortGroupBy(list);

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
            OwnerRepository op = new OwnerRepository();
            IList<Owner> list = await op.GetAll();
            ILinqSorterOwner<Owner> linqSorter = new LinqSorterOwner<Owner>();

            // Act
            var listSorted = linqSorter.SortGroupBy(list);

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
            OwnerRepository op = new OwnerRepository();
            IList<Owner> list = await op.GetAll();
            ILinqSorterOwner<Owner> linqSorter = new LinqSorterOwner<Owner>();

            // Act
            var listSorted = linqSorter.SortGroupBy(list);

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
            OwnerRepository op = new OwnerRepository();
            IList<Owner> list = await op.GetAll();
            ILinqSorterOwner<Owner> linqSorter = new LinqSorterOwner<Owner>();

            // Act
            var listSorted = linqSorter.SortGroupBy(list);

            // Assert
            var male = listSorted[1];
            var maleFirst = male.First();
            var maleSecond = male.Skip(1).First();

            Assert.Equal("Bob", maleFirst.Name);
            Assert.Equal("Fred", maleSecond.Name);
        }

    }
}
