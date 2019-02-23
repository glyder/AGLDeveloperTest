using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public interface ILinqSorterOwner<T>
    {
        IList<IGrouping<string, Owner>> SortGroupBy(IList<Owner> list);
    }
}
