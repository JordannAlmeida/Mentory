using Microsoft.Extensions.Logging;
using System;

namespace WebApi.Modules.Common.Logger
{
    public class ConsoleLoggerConfiguration
    {
        public int EventId { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;

        public ConsoleLoggerConfiguration()
        {
        }

        public ConsoleLoggerConfiguration(LogLevel logLevel, ConsoleColor color)
        {
            LogLevel = logLevel;
            Color = color;
        }
    }
}
