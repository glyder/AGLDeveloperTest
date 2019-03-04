using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public interface ILinqSorterOwner
    {
        IEnumerable<IGrouping<string, Owner>> SortGroupByGender(IEnumerable<Owner> list);
        IEnumerable<Pets> SortGroupByPetType(IGrouping<string, Owner> personGroup,
                                             string petType = "cat");
    }
}
