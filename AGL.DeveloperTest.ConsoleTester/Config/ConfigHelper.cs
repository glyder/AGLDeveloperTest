using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AGL.DeveloperTest.Core;
using Microsoft.Extensions.Configuration;

namespace AGL.DeveloperTest.ConsoleTester.Config
{
    public static class ConfigHelper
    {
        public static IConfigurationRoot ConfigBuild()
        {
            // Config Build
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json");
            var config = builder.Build();
            return config;
        }

        public static void Configuration(IConfigurationRoot config,
                                          out MySettingsConfig configRoot,
                                          out EndpointsConfig configEndpoints)
        {
            // Config - Root/Main
            configRoot = new MySettingsConfig(config["author"],
                                              config["baseUrl"]);
            // Config - Endpoints
            configEndpoints = config.GetSection("endpoints").Get<EndpointsConfig>();
        }

        public static string GetURLByEndpoint(IConfigurationRoot config, string endpoint="people")
        {
            MySettingsConfig configRoot;
            EndpointsConfig configEndpoints;

            Configuration(config, out configRoot, out configEndpoints);


            IURLHelper urlHelper = new URLHelper(configRoot.BaseUrl);
            var fullURL = urlHelper.GetFullEndpointUrl(configRoot.BaseUrl,
                                                       configEndpoints.Owner);
            return fullURL;
        }

    }
}
