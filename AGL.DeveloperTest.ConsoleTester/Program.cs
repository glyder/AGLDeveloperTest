using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGL.DeveloperTest.ConsoleTester
{
    public class Program
    {
        public static IConfigurationRoot _configurationRoot;
        public static ILoggerFactory _loggerFactory;
        public static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            // create service collection - IInterface, etc.
            IServiceCollection serviceCollection = new ServiceCollection();
            ServiceCollectionHelper.ConfigureAddServices(serviceCollection);
            ServiceCollectionHelper.ConfigureAddLogging(serviceCollection);

            // create service provider
            _serviceProvider = serviceCollection.BuildServiceProvider();

            // create build
            _configurationRoot = ConfigBuildHelper.ConfigBuild();

            // Need to call an async method specifically as HTTP client is async
            MainAsync(args, _serviceProvider).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args, 
                                    ServiceProvider serviceProvider)
        {
            // entry to run app
            // serviceProvider.GetService<AppTest>().Run();
            await serviceProvider.GetService<App>().Run(_configurationRoot);
        }

    }

}
