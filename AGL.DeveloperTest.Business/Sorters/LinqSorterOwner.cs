using System.Collections.Generic;
using System.Linq;

using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public class LinqSorterOwner : ILinqSorterOwner
    {
        public IList<IGrouping<string, Owner>> SortGroupByGender(IList<Owner> list)
        {
            var ownerList = list.OrderBy(o => o.Gender)
                                .ThenBy(o => o.Name)
                                .Where(o => o.Pets != null)
                                .GroupBy(o => o.Gender)
                                .ToList();

            return ownerList;
        }

        public List<Pets> SortGroupByPetType(IGrouping<string, Owner> personGroupList,
                                         string petType = "cat")
        {
            var petList = personGroupList.SelectMany(p => p.Pets)
                                         .Where(c => c.Type.ToLower().Equals(petType))
                                         .OrderBy(p => p.Name).ToList();

            return petList;
        }
    }
}
