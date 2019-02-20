using System;
using System.Collections.Generic;
using System.Text;

using Flurl;

namespace AGL.DeveloperTest.Core
{
    public interface IURLHelper
    {
        string GetFullUrl(string endpoint);

        string GetFullUrl(string url, string endpoint);
    }



    public class URLHelper : IURLHelper
    {
        public string BaseURL = @"http://agl-developer-test.azurewebsites.net";

        public string EndPoint = @"people.json";

        public URLHelper()
        {

        }

        public URLHelper(string url) : this()
        {
            this.BaseURL = url;
        }        

        public string GetFullUrl(string endpoint)
        {
            var fullUrl = this.BaseURL.AppendPathSegment(endpoint);
            return fullUrl;
        }

        public string GetFullUrl(string url, string endpoint)
        {
            var fullUrl = url.AppendPathSegment(endpoint)
                             .SetFragment("after-hash");
            return url;
        }
    }

}
