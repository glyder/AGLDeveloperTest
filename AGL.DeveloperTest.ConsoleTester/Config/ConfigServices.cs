using Microsoft.Extensions.DependencyInjection;

using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;
using Microsoft.Extensions.Logging;

namespace AGL.DeveloperTest.ConsoleTester.Config
{
    public static class ConfigServices
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            #region "Add services"

            // Other

            // Models

            // Core
            serviceCollection.AddTransient(typeof(IDeserializer<>), typeof(DeserializerJson<>));
            serviceCollection.AddTransient<IFileReader, FileHelper>();
            serviceCollection.AddTransient<IHttpClient, HttpHelper>();
            serviceCollection.AddTransient<IURLHelper, URLHelper>();
            serviceCollection.AddTransient<ILoggerAGL, LoggerAGL>();

            // Business
            serviceCollection.AddTransient<ILinqSorterOwner, LinqSorterOwner>();
            serviceCollection.AddTransient(typeof(IOwnerRepository<>), typeof(OwnerRepository<>));
            serviceCollection.AddTransient<IConsoleFormatterOwner, ConsoleFormatterOwner>();

            // Services
            serviceCollection.AddTransient<IOwnerService, OwnerService>();
            serviceCollection.AddTransient<ITestService, TestService>();

            // add app
            serviceCollection.AddTransient<AppTest>();
            serviceCollection.AddTransient<App>();

            #endregion
        }

    }
}
