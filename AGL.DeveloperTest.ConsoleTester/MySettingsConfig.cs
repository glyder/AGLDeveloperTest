using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AGL.DeveloperTest.ConsoleTester
{
    public class MySettingsConfig
    {
        public string Author { get; set; }

        public string BaseUrl { get; set; }

        public EndpointsConfig EndpointsConfig { get; set; }

        public MySettingsConfig(string author,
                                string baseUrl)
        {
            Author = author;
            BaseUrl = baseUrl;
        }

    }

    [JsonObject("endpoints")]
    public class EndpointsConfig
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }

    }

}
