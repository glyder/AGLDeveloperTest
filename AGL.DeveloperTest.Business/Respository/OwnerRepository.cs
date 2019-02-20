using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{

    /// <summary>
    /// Repository pattern allows all of your code to use objects without having to know how the objects are persisted. 
    /// All of the knowledge of persistence, including mapping from tables to objects, is safely contained in the repository.
    /// So logical choice of pattern to use here.
    /// </summary>
    public class OwnerRepository : IRepository<Owner>
    {
        #region Properties
        private readonly ILogger _logger;

        private IURLHelper _urlHelper;
        private IHttpClient _httpClient;
        private IDeserializer<Owner> _deserializer;

        private string _endpoint = @"people.json"; 
        #endregion

        /// <summary>
        /// Default constructor used by Testing
        /// </summary>
        public OwnerRepository()
        {
            _urlHelper = new URLHelper(@"http://agl-developer-test.azurewebsites.net");
            _httpClient = new HttpHelper();
            _deserializer = new JsonDeserializer<Owner>();
        }

        public OwnerRepository(IURLHelper urlHelper,
                               IHttpClient httpClient,
                               IDeserializer<Owner> deserializer)
        {
            _urlHelper = urlHelper;
            _httpClient = httpClient;
            _deserializer = deserializer;
        }

        /// <summary>
        /// Retrieve a list of Owners along with their Pets.
        /// </summary>
        /// <returns>IList<Owner></returns>
        public async Task<IList<Owner>> GetAll()
        {
            try
            {
                // 1. Get EndPoint
                string url = _urlHelper.GetFullEndpointUrl(_endpoint);

                // 2. Retrieve text
                string text = await _httpClient.Get(url);

                // 3. Deserialize into Owners list
                IList<Owner> owners = _deserializer.DeserializeText(text);

                return owners;
            }
            catch (Exception ex)
            {
                new Logger().Log(Models.LoggingEventType.Error, ex.Message);
                throw ex;
            }
        }

    }
}
