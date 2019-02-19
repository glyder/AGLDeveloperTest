using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AGL.DeveloperTest.Core
{
    public class HttpHelper : IHttpClient
    {
        #region "Properties"

        public HttpClient HttpClient { get; set; }

        #endregion

        public HttpHelper()
        {
            if (HttpClient == null)
            {
                HttpClient = new HttpClient();
            }
        }

        public async Task<string> Get(string url)
        {
            // Call url in thread
            HttpResponseMessage response = await HttpClient.GetAsync(url);

            // Get content
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

    }
}
