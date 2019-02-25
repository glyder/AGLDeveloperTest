
using Flurl;

namespace AGL.DeveloperTest.Core
{
    public class URLHelper : IURLHelper
    {
        public string BaseURL = @"http://agl-developer-test.azurewebsites.net";
        public string EndPoint = @"people.json";

        public URLHelper()
        {

        }

        public URLHelper(string url) : this()
        {
            this.BaseURL = url;
        }        

        public string GetFullEndpointUrl(string endpoint)
        {
            var fullUrl = this.BaseURL.AppendPathSegment(endpoint);

            return fullUrl;
        }

        public string GetFullEndpointUrl(string url, string endpoint)
        {
            var fullUrl = url.AppendPathSegment(endpoint);

            return fullUrl;
        }
    }

}
