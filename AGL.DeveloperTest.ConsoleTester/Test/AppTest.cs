using System;

using AGL.DeveloperTest.Services;

namespace AGL.DeveloperTest.ConsoleTester
{
    public class AppTest
    {
        private readonly ITestService _testService;

        public AppTest(ITestService testService)
        {
            _testService = testService;
        }

        public void Run()
        {
            _testService.Run();
        }
    }
}
