using Xunit;

using AGL.DeveloperTest.Core;

namespace CoreTests
{
    public class URLHelperTests
    {

        [Fact]
        [Trait("Category", "Business")]
        public void URLHelper_GetFullEndpointUrl_True()
        {
            // Arrange
            URLHelper urlHelper = new URLHelper();

            // Act
            string url = urlHelper.GetFullEndpointUrl("people.json");

            // Assert
            Assert.Equal(@"http://agl-developer-test.azurewebsites.net/people.json",
                         url);
        }


    }
}
