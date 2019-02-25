using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using AGL.DeveloperTest.ConsoleTester.Config;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;

namespace AGL.DeveloperTest.ConsoleTester
{
    /// <summary>
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            string urlPeopleJSON = "";

            #region "Config / appSettings"

            IConfigurationRoot config = ConfigHelper.ConfigBuild();
            urlPeopleJSON = ConfigHelper.GetURLByEndpoint(config, "people");

            #endregion

            #region "Owner Data / Formatter"

            // Define Services/Formatters
            IOwnerService ownerService = new OwnerService();
            IConsoleFormatterOwner ownerConsoleFormatter = new ConsoleFormatterOwner();

            // Get Data via service
            var listOwnerGrouping = await ownerService.GetAll();

            // Console write data with formatter
            // ownerConsoleFormatter.DisplayAllByGender(listOwnerGrouping);
            ownerConsoleFormatter.DisplayAllByGenderPets(listOwnerGrouping);

            #endregion

        }
    }

}
