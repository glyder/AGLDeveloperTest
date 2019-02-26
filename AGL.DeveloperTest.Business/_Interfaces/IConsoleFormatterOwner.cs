using System.Linq;
using System.Collections.Generic;

using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public interface IConsoleFormatterOwner
    {
        void DisplayAllByGender(IList<IGrouping<string, Owner>> listOwnerGrouping);

        void DisplayAllByGenderPets(IList<IGrouping<string, Owner>> listOwnerGrouping, string petType = "cat");

        void DisplayKeyHeading(string key);
    }

}
