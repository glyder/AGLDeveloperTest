using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Business
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
    }
    
    public class OwnerRepository : IRepository<Owner>
    {
        private IURLHelper _urlHelper;
        private IHttpClient _httpClient;
        private IDeserializer<Owner> _deserializer;

        private string _endpoint = @"people.json";

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

        public async Task<IList<Owner>> GetAll()
        {
            try
            {
                // 1. Get EndPoint
                string url = _urlHelper.GetFullUrl(_endpoint);

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
