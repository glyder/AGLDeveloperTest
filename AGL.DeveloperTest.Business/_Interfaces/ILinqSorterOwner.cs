using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public interface ILinqSorterOwner
    {
        IList<IGrouping<string, Owner>> SortGroupByGender(IList<Owner> list);
        List<Pets> SortGroupByPetType(IGrouping<string, Owner> personGroup,
                                      string petType = "cat");
    }
}
