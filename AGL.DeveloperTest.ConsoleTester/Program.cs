using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using AGL.DeveloperTest.ConsoleTester.Config;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AGL.DeveloperTest.ConsoleTester
{
    /// <summary>
    /// </summary>
    public class Program
    {

        public static ILoggerFactory LoggerFactory;
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigServices.ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();


            // Need to call an async method specifically as HTTP client is async
            MainAsync(args, serviceProvider).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args, 
                                    ServiceProvider serviceProvider)
        {

            #region "Config / appSettings"


            #endregion

            // entry to run app
            // serviceProvider.GetService<AppTest>().Run();
            await serviceProvider.GetService<App>().Run();
        }

    }

}
