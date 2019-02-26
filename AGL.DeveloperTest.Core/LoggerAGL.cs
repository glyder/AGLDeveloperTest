using System.Diagnostics;

using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Core
{
    public class LoggerAGL : ILoggerAGL
    {
        public void Log(LoggingEventType entry, string message)
        {
            // TODO: Implement your favourite logger here
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2
            // https://github.com/NLog/NLog.Web/wiki/Getting-started-with-ASP.NET-Core-2
            Trace.WriteLine(message, entry.ToString());
            // Debug.WriteLine("Debug: " + message, entry.ToString());
        }
    }
}
