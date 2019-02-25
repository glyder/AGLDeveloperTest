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

        /// <summary>
        /// For Testing purpose inject MOQs here
        /// </summary>
        /// <param name="httpClient"></param>
        public HttpHelper(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<string> Get(string url)
        {
            // Call url in thread
            string response = await HttpClient.GetStringAsync(url);

            return response;
        }

    }
}
