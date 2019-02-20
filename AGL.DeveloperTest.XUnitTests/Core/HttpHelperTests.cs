using Xunit;

using AGL.DeveloperTest.Core;

namespace CoreTests
{
    public class HttpHelperTests
    {
        #region "Properties"

        const string GOOGLEURL = "http://google.com";
        const string AGLWEBURL = "http://agl-developer-test.azurewebsites.net/people.json";

        #endregion

        [Fact]
        [Trait("Category", "Core")]
        public async void GetWebContent_FromGoogleUrl_True()
        {
            // Arrange
            string responseText = "";
            IHttpClient client = new HttpHelper();

            // Act 
            responseText = await client.Get(GOOGLEURL);

            // Assert
            Assert.NotEmpty(responseText);
            Assert.StartsWith("<!doctype html>", responseText);
        }

        [Fact]
        [Trait("Category", "Core")]
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
