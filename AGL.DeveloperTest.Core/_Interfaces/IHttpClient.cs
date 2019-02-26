
using System.Threading.Tasks;

namespace AGL.DeveloperTest.Core
{
    public interface IHttpClient
    {
        Task<string> Get(string url);
    }
}
