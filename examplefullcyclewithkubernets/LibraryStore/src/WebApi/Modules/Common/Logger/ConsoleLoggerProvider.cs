using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace WebApi.Modules.Common.Logger
{
    public sealed class ConsoleLoggerProvider : ILoggerProvider
    {
        private readonly ConsoleLoggerConfiguration _config;

        private readonly ConcurrentDictionary<string, ConsoleLogger> _loggers =
            new();

        public ConsoleLoggerProvider(ConsoleLoggerConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new ConsoleLogger(_config));

        public void Dispose() => _loggers.Clear();
    }
}
