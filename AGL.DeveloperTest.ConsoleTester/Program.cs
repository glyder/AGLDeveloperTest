using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Services;

using AGL.DeveloperTest.ConsoleTester.Config;

namespace AGL.DeveloperTest.ConsoleTester
{
    /// <summary>
    /// https://garywoodfine.com/configuration-api-net-core-console-application/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string peopleGetUrl = "";

            #region "Config / appSettings"

            IConfigurationRoot config = ConfigHelper.ConfigBuild();
            peopleGetUrl = ConfigHelper.GetURLByEndpoint(config, "people");

            #endregion


            MainAsync(args).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            IOwnerService ownerService = new OwnerService();

            IList<Owner> ownerFemaleList = await ownerService.GetByGender("Female", true);
            IList<Owner> ownerMaleList = await ownerService.GetByGender("Male", true);

            Console.WriteLine("Female");
            foreach (var owner in ownerFemaleList)
            {
                Console.WriteLine($"\t{owner.Name}");
            }

            Console.WriteLine("Male");
            foreach (var owner in ownerMaleList)
            {
                Console.WriteLine($"\t{owner.Name}");
            }

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
