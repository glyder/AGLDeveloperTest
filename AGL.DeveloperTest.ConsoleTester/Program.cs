using System;
using System.IO;
using AGL.DeveloperTest.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;



namespace AGL.DeveloperTest.ConsoleTester
{
    /// <summary>
    /// https://garywoodfine.com/configuration-api-net-core-console-application/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MySettingsConfig configRoot;
            EndpointsConfig configEndpoints;


            // Config Build
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json");
            var config = builder.Build();

            // Get appsettings.json
            Configuration(config, out configRoot, out configEndpoints);


            IURLHelper urlHelper = new URLHelper(configRoot.BaseUrl);
            var fullURL = urlHelper.GetFullEndpointUrl(configRoot.BaseUrl,
                                                       configEndpoints.Owner);
            Console.WriteLine($"{ fullURL }");

            Console.ReadLine();
        }

        private static void Configuration(IConfigurationRoot config, 
                                          out MySettingsConfig configRoot, 
                                          out EndpointsConfig configEndpoints)
        {
            // Config - Root/Main
            configRoot = new MySettingsConfig(config["author"],
                                              config["baseUrl"]);
            // Config - Endpoints
            configEndpoints = config.GetSection("endpoints").Get<EndpointsConfig>();
        }
    }

    #region DummyClasses

    public interface IFooService
    {
        void DoThing(int number);
    }

    public interface IBarService
    {
        void DoSomeRealWork();
    }

    public class BarService : IBarService
    {
        private readonly IFooService _fooService;
        public BarService(IFooService fooService)
        {
            _fooService = fooService;
        }

        public void DoSomeRealWork()
        {
            for (int i = 0; i < 10; i++)
            {
                _fooService.DoThing(i);
            }
        }
    }

    public class FooService : IFooService
    {
        private readonly ILogger<FooService> _logger;
        public FooService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FooService>();
        }

        public void DoThing(int number)
        {
            _logger.LogInformation($"Doing the thing {number}");
        }
    }

    #endregion
}
