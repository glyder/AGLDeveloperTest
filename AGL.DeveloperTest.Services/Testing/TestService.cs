using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.DeveloperTest.Services
{
    public interface ITestService
    {
        void Run();
    }

    public class TestService : ITestService
    {
        public void Run()
        {
            // Console.WriteLine("TestService is running!");
        }
    }
}
