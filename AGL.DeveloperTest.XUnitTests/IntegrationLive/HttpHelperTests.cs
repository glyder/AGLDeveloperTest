using Xunit;

using System.Net.Http;

// using RichardSzalay.MockHttp;

using AGL.DeveloperTest.Core;
using AGL.Base;
using System.IO;

namespace IntegrationTests
{
    public class HttpHelperTests : BaseTests
    {
        #region "Properties"

        const string GOOGLEURL = "http://google.com";
        const string AGLWEBURL = "http://agl-developer-test.azurewebsites.net/people.json";

        #endregion

        [Theory]
        [InlineData(GOOGLEURL, "<!doctype html>", "doctype")]
        [InlineData(AGLWEBURL, "[{\"name\":\"Bob\",\"gender\":\"Male\",", "gender")]
        [Trait("Category", "IntegrationLive")]
        public async void GetWebContent_FromUrl_True(string url,
                                                     string expectedStartsWith,
                                                     string expectedContains)
        {
            // Arrange
            string responseText = "";
            IHttpClient client = new HttpHelper();

            // Act 
            responseText = await client.Get(url);

            // Assert
            Assert.NotEmpty(responseText);
            Assert.StartsWith(expectedStartsWith, responseText);
            Assert.Contains(expectedContains, responseText);
        }

        [Fact]
        [Trait("Category", "IntegrationLive")]
        public async void GetJSONContent_FromAGLUrl_True()
        {
            // Arrange
            string responseText = "";
            IHttpClient client = new HttpHelper();

            // Act 
            responseText = await client.Get(AGLWEBURL);

            // Assert
            Assert.NotEmpty(responseText);
            Assert.Contains("name", responseText);
            Assert.Contains("pets", responseText);
        }

    }
}
