using System.IO;

using Microsoft.Extensions.Configuration;

using AGL.DeveloperTest.Core;

namespace AGL.DeveloperTest.ConsoleTester
{
    public static class ConfigBuildHelper
    {
        public static IConfigurationRoot ConfigBuild()
        {
            // Config Build setup settings
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return config;
        }

        public static void Configuration(IConfigurationRoot config,
                                         out AppSettingsConfig appSettings)
        {
            // Config - Root/Main
            appSettings = new AppSettingsConfig(config["Author"], config["BaseUrl"]);
            appSettings.RunInternetTests = bool.Parse(config["RunIntegrationLiveTests"]);

            // Config - Endpoints
            appSettings.EndpointsConfig = config.GetSection("endpoints").Get<EndpointsConfig>();
            
        }

        public static string GetURLByEndpoint(IConfigurationRoot config, string endpoint="people")
        {
            AppSettingsConfig appSettings;

            Configuration(config, out appSettings);

            IURLHelper urlHelper = new URLHelper(appSettings.BaseUrl);
            var fullURL = urlHelper.GetFullEndpointUrl(appSettings.BaseUrl,
                                                       appSettings.EndpointsConfig.Owner);
            return fullURL;
        }

    }
}
