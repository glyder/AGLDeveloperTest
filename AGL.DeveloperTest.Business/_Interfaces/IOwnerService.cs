using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public interface IOwnerService
    {
        Task<IList<IGrouping<string, Owner>>> GetAll();
        Task<IList<Owner>> GetByGender(string gender, bool sortByName = false);
    }
}
