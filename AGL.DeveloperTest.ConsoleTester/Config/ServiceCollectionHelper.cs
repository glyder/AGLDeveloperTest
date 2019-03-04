using System;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using AGL.DeveloperTest.Core;
using AGL.DeveloperTest.Business;
using AGL.DeveloperTest.Services;

namespace AGL.DeveloperTest.ConsoleTester
{
    public static class ServiceCollectionHelper
    {
        public static void ConfigureAddServices(IServiceCollection serviceCollection)
        {
            #region "Add services"

            // Core
            serviceCollection
                .AddTransient(typeof(IDeserializer<>), typeof(DeserializerJson<>))
                .AddTransient<IFileReader, FileHelper>()
                .AddTransient<IHttpClient, HttpClientHelper>()
                .AddTransient<IURLHelper, URLHelper>()
                .AddTransient<ILoggerAGL, LoggerAGL>();
                
            // Business
            serviceCollection
                .AddTransient<ILinqSorterOwner, LinqSorterOwner>()
                .AddTransient(typeof(IOwnerRepository<>), typeof(OwnerRepository<>))
                .AddTransient<IConsoleFormatterOwner, ConsoleFormatterOwner>();

            // Services
            serviceCollection
                .AddTransient<ITestService, TestService>()
                .AddTransient<IOwnerService, OwnerService>();

            // add main apps
            serviceCollection
                .AddTransient<AppTest>()
                .AddTransient<App>();

            // Other

            #endregion
        }

        public static void ConfigureAddLogging(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddLogging(config => {

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

        }

    }
}
