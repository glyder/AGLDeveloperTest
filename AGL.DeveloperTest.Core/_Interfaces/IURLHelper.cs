
namespace AGL.DeveloperTest.Core
{
    public interface IURLHelper
    {
        string GetFullEndpointUrl(string endpoint);

        string GetFullEndpointUrl(string url, string endpoint);
    }
}
