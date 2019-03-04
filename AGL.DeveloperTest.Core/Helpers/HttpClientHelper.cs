using System.Net.Http;
using System.Threading.Tasks;

namespace AGL.DeveloperTest.Core
{
    public class HttpClientHelper : IHttpClient
    {
        #region "Properties"

        public HttpClient HttpClient { get; set; }

        #endregion

        public HttpClientHelper()
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
        public HttpClientHelper(HttpClient httpClient)
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
