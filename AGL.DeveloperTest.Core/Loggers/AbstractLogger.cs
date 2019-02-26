using System;

using Microsoft.Extensions.Logging;

namespace AGL.DeveloperTest.Core
{
    /// <summary>
    /// https://medium.com/@whuysentruit/unit-testing-ilogger-in-asp-net-core-9a2d066d0fb8
    ///
    ///   Which is better? 
    ///   Mock<ILogger<OwnerService>> _loggerMock = new Mock<ILogger<OwnerService>>();
    ///   Mock<AbstractLogger<OwnerService>> _loggerMock = new Mock<AbstractLogger<OwnerService>>();
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractLogger<T> : ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state)
            => throw new NotImplementedException();

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            => Log(logLevel, exception, formatter(state, exception));

        public abstract void Log(LogLevel logLevel, Exception ex, string information);
    }
}
