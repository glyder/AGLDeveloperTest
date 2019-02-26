using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Core
{
    public interface ILoggerAGL
    {
        void Log(LoggingEventType entry, string message);
    }
}
