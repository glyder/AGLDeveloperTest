using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;
using Microsoft.Extensions.Configuration;
using AGL.DeveloperTest.ConsoleTester.Config;

namespace AGL.DeveloperTest.ConsoleTester
{
    public class App
    {
        private readonly ITestService _testService;
        private readonly ILogger<App> _logger;

        private readonly IOwnerService _ownerService;
        private readonly IConsoleFormatterOwner _consoleFormatterOwner;
        

        public App(ITestService testService,
                   ILogger<App> logger,
                   
                   IOwnerService ownerService,
                   IConsoleFormatterOwner consoleFormatterOwner)
        {
            _testService = testService;
            _logger = logger;

            _ownerService = ownerService;
            _consoleFormatterOwner = consoleFormatterOwner;
        }

        public async Task Run()
        {
            string urlPeopleJSON = "";
            IConfigurationRoot config = ConfigHelper.ConfigBuild();
            urlPeopleJSON = ConfigHelper.GetURLByEndpoint(config, "people");
            // _logger.LogInformation($"{urlPeopleJSON }");

            // Get Data via service
            var listOwnerGrouping = await _ownerService.GetAll();

            // Console write data with formatter
            // _consoleFormatterOwner.DisplayAllByGender(listOwnerGrouping);
            _consoleFormatterOwner.DisplayAllByGenderPets(listOwnerGrouping);

            Console.ReadKey();
        }
    }
}
