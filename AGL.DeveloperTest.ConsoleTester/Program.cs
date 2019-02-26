using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using AGL.DeveloperTest.ConsoleTester.Config;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AGL.DeveloperTest.ConsoleTester
{
    /// <summary>
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigServices.ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<AppTest>().Run();

            MainAsync(args, serviceProvider).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args, 
                                    ServiceProvider serviceProvider)
        {

            #region "Config / appSettings"

            string urlPeopleJSON = "";
            IConfigurationRoot config = ConfigHelper.ConfigBuild();
            urlPeopleJSON = ConfigHelper.GetURLByEndpoint(config, "people");

            #endregion

            await serviceProvider.GetService<App>().Run();
        }

    }

}
