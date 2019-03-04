using Xunit;

using AGL.DeveloperTest.Core;
using AGL.Base;

namespace IntegrationTests
{
    public class HttpHelperTests : BaseTests
    {
        #region "Properties"

        const string GOOGLEURL = "http://google.com";
        const string AGLWEBURL = "http://agl-developer-test.azurewebsites.net/people.json";

        #endregion

        [SkippableTheory]
        //[Theory]
        [InlineData(GOOGLEURL, "<!doctype html>", "doctype")]
        [InlineData(AGLWEBURL, "[{\"name\":\"Bob\",\"gender\":\"Male\",", "gender")]
        [Trait("Category", "IntegrationLive")]
        public async void GetWebContent_FromUrl_True(string url,
                                                     string expectedStartsWith,
                                                     string expectedContains)
        {
            Skip.If(base.stopIntegrationLiveTests);

            // Arrange
            string responseText = "";
            IHttpClient client = new HttpClientHelper();

            // Act 
            responseText = await client.Get(url);

            // Assert
            Assert.NotEmpty(responseText);
            Assert.StartsWith(expectedStartsWith, responseText);
            Assert.Contains(expectedContains, responseText);
        }

        [SkippableFact]
        // [Fact]
        [Trait("Category", "IntegrationLive")]
        public async void GetJSONContent_FromAGLUrl_True()
        {
            Skip.If(base.stopIntegrationLiveTests);

            // Arrange
            string responseText = "";
            IHttpClient client = new HttpClientHelper();

            // Act 
            responseText = await client.Get(AGLWEBURL);

            // Assert
            Assert.NotEmpty(responseText);
            Assert.Contains("name", responseText);
            Assert.Contains("pets", responseText);
        }

    }
}
