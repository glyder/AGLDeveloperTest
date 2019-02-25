
using System;
using System.Collections.Generic;
using System.Linq;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public interface IConsoleFormatterOwner
    {
        void DisplayAllByGender(IList<IGrouping<string, Owner>> listOwnerGrouping);

        void DisplayAllByGenderPets(IList<IGrouping<string, Owner>> listOwnerGrouping, string petType = "cat");

        void DisplayKeyHeading(string key);
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleFormatterOwner : IConsoleFormatterOwner
    {
        const string BULLETPOINT = "\u2022";


        public ConsoleFormatterOwner()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void DisplayAllByGender(IList<IGrouping<string, Owner>> listOwnerGrouping)
        {
            foreach (var group in listOwnerGrouping)
            {
                string key = group.Key;
                IList<Owner> listOwnerGroup = group.ToList();

                this.DisplayKeyHeading(key);

                foreach (var owner in listOwnerGroup)
                {
                    Console.WriteLine($"\u2022 {owner.Name}");
                }

                Console.WriteLine();
            }
        }

        public void DisplayAllByGenderPets(IList<IGrouping<string, Owner>> listOwnerGrouping,
                                           string petType = "cat")
        {
            ILinqSorterOwner linqSorterOwner = new LinqSorterOwner();

            foreach (var group in listOwnerGrouping)
            {
                string key = group.Key;
                IList<Owner> listOwnerGroup = group.ToList();

                this.DisplayKeyHeading(key);

                //foreach (var owner in listOwnerGroup) { Console.WriteLine($"\u2022 {owner.Name}");
                    foreach (var pet in linqSorterOwner.SortGroupByPetType(group))
                    {
                        Console.WriteLine($"  {BULLETPOINT} {pet.Name}");
                    }
                //}

                Console.WriteLine();
            }

        }


        public void DisplayKeyHeading(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                Console.WriteLine(key);
                Console.WriteLine(new String('=', key.Length));
            }
        }
    }
}
