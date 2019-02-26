using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Moq;

using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Models;


namespace AGL.Base
{
    public abstract class BaseTests : IDisposable
    {
        #region "Properties"

        public readonly string PEOPLE_FILE_JSON = Directory.GetCurrentDirectory() +
                                                  @"\_Data\people.json";

        public readonly bool runLiveTests = true;

        #endregion

        #region "Constructors/Destructor"

        protected BaseTests()
        {
            // Do "global" initialization here; Called before every test method.
        }

        public virtual void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
        }

        #endregion

        #region "Helpers"

        /// <summary>
        /// For MOQ use, read all JSON text from file
        /// </summary>
        /// <param name="path">path of file to read</param>
        /// <returns>string text of file</returns>
        protected virtual string helperGetSONFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// For MOQ use, List of Owners from text
        /// </summary>
        /// <param name="jsonText">text to convert to list</param>
        /// <returns>IList Owner</returns>
        protected virtual IList<Owner> helperGetListOwnerFromJson(string jsonText)
        {
            IDeserializer<Owner> deserializerOwner = new DeserializerJson<Owner>();

            IList<Owner> listOwner = deserializerOwner.DeserializeText(jsonText);            

            return listOwner;
        }

        /// <summary>
        /// For MOQ use, combine read JSON file and deserializer to List of Owner
        /// </summary>
        /// <param name="path">path of file to read</param>
        /// <returns>IList Owner</returns>
        protected virtual IList<Owner> helperGetListOwnerFromFile(string path)
        {
            string jsonText = this.helperGetSONFromFile(path);

            return this.helperGetListOwnerFromJson(jsonText);
        }

        #endregion

        #region "MOQs"

        protected virtual Mock<IURLHelper> MoqURLHelper()
        {
            Mock<IURLHelper> _urlHelper = _urlHelper = new Mock<IURLHelper>();

            _urlHelper.Setup(x => x.GetFullEndpointUrl(It.IsAny<string>()))
                      .Returns("http://agl-developer-test.azurewebsites.net/people.json");

            _urlHelper.Setup(x => x.GetFullEndpointUrl(It.IsAny<string>(), It.IsAny<string>()))
                      .Returns("http://agl-developer-test.azurewebsites.net/people.json");

            return _urlHelper;
        }

        protected virtual Mock<IDeserializer<Owner>> MoqDeserializerOwner()
        {
            Mock<IDeserializer<Owner>> _deserializerOwner = new Mock<IDeserializer<Owner>>();

            _deserializerOwner.Setup(x => x.DeserializeText(It.IsAny<string>()))
                              .Returns(this.helperGetListOwnerFromFile(PEOPLE_FILE_JSON));

            return _deserializerOwner;
        }

        protected virtual async Task<IHttpClient> MockHttpClient()
        {
            var httpClient = new HttpClient(new MockHttpMessageHandler(MockHttpMessageHandlerObjectType.FilePath, 
                                                                       PEOPLE_FILE_JSON));
            IHttpClient httpHelper = new HttpHelper(httpClient);
            var content = await httpClient.GetStringAsync("http://some.fake.url");

            return httpHelper;
        }

        protected virtual async Task<IHttpClient> MockHttpClient(MockHttpMessageHandlerObjectType type,
                                                                 string objectType)
        {
            var httpClient = new HttpClient(new MockHttpMessageHandler(type, objectType));
            IHttpClient httpHelper = new HttpHelper(httpClient);
            var content = await httpClient.GetStringAsync("http://some.fake.url");

            return httpHelper;
        }



        #endregion

    }
}
