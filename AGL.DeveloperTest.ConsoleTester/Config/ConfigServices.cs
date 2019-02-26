using Microsoft.Extensions.DependencyInjection;

using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System;

namespace AGL.DeveloperTest.ConsoleTester.Config
{
    public static class ConfigServices
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            #region "Add services"

            // Core
            serviceCollection
                .AddTransient(typeof(IDeserializer<>), typeof(DeserializerJson<>))
                .AddTransient<IFileReader, FileHelper>()
                .AddTransient<IHttpClient, HttpHelper>()
                .AddTransient<IURLHelper, URLHelper>()
                .AddTransient<ILoggerAGL, LoggerAGL>();

            // Business
            serviceCollection
                .AddTransient<ILinqSorterOwner, LinqSorterOwner>()
                .AddTransient(typeof(IOwnerRepository<>), typeof(OwnerRepository<>))
                .AddTransient<IConsoleFormatterOwner, ConsoleFormatterOwner>();

            // Services
            serviceCollection
                .AddTransient<IOwnerService, OwnerService>()
                .AddTransient<ITestService, TestService>();

            // add app
            serviceCollection
                .AddTransient<AppTest>()
                .AddTransient<App>();

            // add logging
            serviceCollection.AddLogging(config => {

                // clear out default configuration
                config.ClearProviders();

                //config.AddConfiguration(Configuration.GetSection("Logging"));
                //config.AddDebug();
                //config.AddEventSourceLogger();

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == EnvironmentName.Development)
                {
                    config.AddConsole();
                }

                // config.AddConsole();
                config.AddDebug();
            });

            // Other

            #endregion
        }

    }
}
