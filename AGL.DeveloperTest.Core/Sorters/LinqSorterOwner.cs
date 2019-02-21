using System.Collections.Generic;
using System.Linq;

using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Core
{
    public interface ILinqSorterOwner<T>
    {
        IList<IGrouping<string, Owner>> SortGroupBy(IList<Owner> list);
    }

    public class LinqSorterOwner<T> : ILinqSorterOwner<T>
    {
        public IList<IGrouping<string, Owner>> SortGroupBy(IList<Owner> list)
        {
            var ownerList = list.OrderBy(p => p.Gender)
                                .OrderBy(p => p.Name)           // ThenByDescending
                                .Where(p => p.Pets != null)
                                .GroupBy(p => p.Gender)
                                .ToList();

            return ownerList;
        }

    }
}
