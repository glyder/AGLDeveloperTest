using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Core
{
    public interface ILogger
    {
        void Log(LoggingEventType entry, string message);
    }
}
