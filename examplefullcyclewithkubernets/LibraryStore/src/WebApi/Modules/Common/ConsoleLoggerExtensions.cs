using Microsoft.Extensions.Logging;
using System;
using WebApi.Modules.Common.Logger;

namespace WebApi.Modules.Common
{
    public static class ConsoleLoggerExtensions
    {
        public static ILoggingBuilder AddConsoleLogger(this ILoggingBuilder builder) =>
            builder.AddConsoleLogger(new ConsoleLoggerConfiguration());

        public static ILoggingBuilder AddConsoleLogger(this ILoggingBuilder builder, LogLevel logLevel, ConsoleColor consoleColor) =>
            builder.AddConsoleLogger(new ConsoleLoggerConfiguration(logLevel, consoleColor));

        public static ILoggingBuilder AddConsoleLogger(this ILoggingBuilder builder, Action<ConsoleLoggerConfiguration> configure)
        {
            var config = new ConsoleLoggerConfiguration();
            configure(new ConsoleLoggerConfiguration());

            return builder.AddConsoleLogger(config);
        }

        public static ILoggingBuilder AddConsoleLogger(this ILoggingBuilder builder, ConsoleLoggerConfiguration config)
        {
            builder.AddProvider(new ConsoleLoggerProvider(config));
            return builder;
        }
    }
}