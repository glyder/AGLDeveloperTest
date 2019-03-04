using System;
using System.Collections.Generic;
using System.Linq;

using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public class LinqSorterOwner : ILinqSorterOwner
    {
        public IEnumerable<IGrouping<string, Owner>> SortGroupByGender(IEnumerable<Owner> list)
        {
            var ownerList = list.OrderBy(o => o.Gender)
                                .ThenBy(o => o.Name)
                                .Where(o => o.Pets != null)
                                .GroupBy(o => o.Gender);

            return ownerList;
        }

        public IEnumerable<Pets> SortGroupByPetType(IGrouping<string, Owner> personGroupList,
                                             string petType = "cat")
        {
            var petList = personGroupList.SelectMany(p => p.Pets)
                                         .Where(c => c.Type.ToLower().Equals(petType))
                                         .OrderBy(p => p.Name);

            return petList;
        }

    }


    //TODO: MyLinq
    public static class MyLinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, 
                                               Func<T, bool> predicate)
        {
            // 2
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }


            // 1
            //var result = new List<T>();

            //foreach(var item in source)
            //{
            //    if (predicate(item))
            //    {
            //        result.Add(item);
            //    }
            //}

            //return result;
        }
    }
}
