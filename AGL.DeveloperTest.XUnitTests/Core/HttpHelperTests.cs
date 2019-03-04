using Xunit;

using System.Net.Http;

// using RichardSzalay.MockHttp;

using AGL.DeveloperTest.Core;
using AGL.Base;
using System.IO;

namespace CoreTests
{
    public class HttpHelperTests : BaseTests
    {
        #region "Properties"

        const string GOOGLEURL = "http://google.com";
        const string AGLWEBURL = "http://agl-developer-test.azurewebsites.net/people.json";

        #endregion

        [Theory]
        [InlineData(AGLWEBURL, "[\r\n    {\r\n        \"name\": \"Bob\",", "name")]
        [Trait("Category", "Core")]
        public async void GetWebContent_FromUrl_True(string url,
                                                     string expectedStartsWith,
                                                     string expectedContains)
        {
            // Arrange
            string responseText = "";
            IHttpClient _httpClientMock = await base.MockHttpClient(MockHttpMessageHandlerObjectType.FilePath,
                                                                base.PEOPLE_FILE_JSON);

            // Act 
            responseText = await _httpClientMock.Get(url);

            // Assert
            Assert.NotEmpty(responseText);
            Assert.StartsWith(expectedStartsWith, responseText);
            Assert.Contains(expectedContains, responseText);
        }

        [Fact] // (Skip = "To be mocked")]
        [Trait("Category", "Core")]
        public async void GetJSONContent_FromAGLUrl_True()
        {
            // Arrange
            string responseText = "";
            IHttpClient _httpClientMock = await base.MockHttpClient(MockHttpMessageHandlerObjectType.FilePath,
                                                                base.PEOPLE_FILE_JSON);

            // Act 
            responseText = await _httpClientMock.Get(AGLWEBURL);

            // Assert
            Assert.NotEmpty(responseText);
            Assert.Contains("name", responseText);
            Assert.Contains("pets", responseText);
        }


        [Theory]
        [InlineData(AGLWEBURL, "[\r\n    {\r\n        \"name\": \"Bob\",", "name")]
        [Trait("Category", "Core")]
        public async void GetWebContent_FromUrlMocked_True(string url,
                                                           string expectedStartsWith,
                                                           string expectedContains)
        {
            // Arrange
            string responseText = "";
            IHttpClient _httpClientMock = await base.MockHttpClient(MockHttpMessageHandlerObjectType.FilePath,
                                                                base.PEOPLE_FILE_JSON);


            // Act 
            responseText = await _httpClientMock.Get(url);

            // Assert
            Assert.NotEmpty(responseText);
            Assert.StartsWith(expectedStartsWith, responseText);
            Assert.Contains(expectedContains, responseText);
        }

    }
}
