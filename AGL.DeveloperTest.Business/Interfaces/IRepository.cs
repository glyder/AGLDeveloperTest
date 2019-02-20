using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGL.DeveloperTest.Business
{
    /// <summary>
    /// As a summary, I would describe the wider impact of the repository pattern. It allows all of your code to use objects without having to know how the objects are persisted. All of the knowledge of persistence, including mapping from tables to objects, is safely contained in the repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
    }

}
