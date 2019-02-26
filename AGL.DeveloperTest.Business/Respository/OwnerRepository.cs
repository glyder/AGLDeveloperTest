using System;
using System.Collections.Generic;
using System.Linq;
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
    public class OwnerRepository<T> : IOwnerRepository<T>
    {
        #region Properties
        // private readonly ILogger _logger;

        private IURLHelper _urlHelper;
        private IHttpClient _httpClient;
        private IDeserializer<T> _deserializer;

        private string _endpoint = @"people.json";
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor used by Testing
        /// </summary>
        public OwnerRepository()
        {
            _urlHelper = new URLHelper(@"http://agl-developer-test.azurewebsites.net");
            _httpClient = new HttpHelper();
            _deserializer = new DeserializerJson<T>();
        }

        public OwnerRepository(IURLHelper urlHelper,
                               IHttpClient httpClient,
                               IDeserializer<T> deserializer)
        {
            _urlHelper = urlHelper;
            _httpClient = httpClient;
            _deserializer = deserializer;
        }

        #endregion

        /// <summary>
        /// Retrieve a list of Owners along with their Pets.
        /// </summary>
        /// <returns>IList<Owner></returns>
        public async Task<IList<T>> GetAll()
        {
            try
            {
                // 1. Get Full URL (with EndPoint)
                string httpUrl = _urlHelper.GetFullEndpointUrl(_endpoint);

                // 2. Retrieve text from URL
                string text = await _httpClient.Get(httpUrl);

                // 3. Deserialize text JSON into Owners list
                IList<T> owners = _deserializer.DeserializeText(text);

                return owners;
            }
            catch (Exception ex)
            {
                new LoggerAGL().Log(LoggingEventType.Error, ex.Message);
                throw ex;
            }
        }

        public async Task<IList<T>> GetByGender(string gender)
        {
            try
            {
                IList<T> listOwnerByGender = await GetAll();

                IList<T> ListOwnerByGenderFiltered =
                    listOwnerByGender.Where(x => x.GetType().GetProperty("Gender").GetValue(x, null) == gender)
                                     .ToList();

                return ListOwnerByGenderFiltered;
            }
            catch (Exception ex)
            {
                new LoggerAGL().Log(LoggingEventType.Error, ex.Message);
                throw ex;
            }
        }
    }
}
