using Microsoft.Extensions.Logging;
using System;

namespace WebApi.Modules.Common.Logger
{
    public class ConsoleLogger : ILogger
    {
        private readonly ConsoleLoggerConfiguration _config;
        private readonly object _MessageLock = new();

        public ConsoleLogger(ConsoleLoggerConfiguration config) =>
            _config = config;

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) =>
            logLevel == _config.LogLevel;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            if ((_config.EventId == 0 || _config.EventId == eventId.Id) &&
                state != null && !string.IsNullOrEmpty(state.ToString()))
            {
                lock (_MessageLock)
                {
                    Console.ForegroundColor = _config.Color;
                    Console.Write($"[{logLevel,-11}] - {DateTime.Now:dd/MM/yyyy HH:mm:ss} : ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{state}");
                }
            }
        }
    }
}
