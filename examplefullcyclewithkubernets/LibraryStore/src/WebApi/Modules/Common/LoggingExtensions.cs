namespace WebApi.Modules.Common
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    public static class LoggingExtensions
    {

        public static ILoggingBuilder AddLoggerByEnvironment(this ILoggingBuilder loggingBuilder, WebHostBuilderContext context)
        {
            var environment = context.HostingEnvironment;
            var configuration = context.Configuration;

            return loggingBuilder.AddLoggerByEnvironment(configuration, environment);
        }

        public static ILoggingBuilder AddLoggerByEnvironment(this ILoggingBuilder loggingBuilder)
        {
            var serviceProvider = loggingBuilder.Services.BuildServiceProvider();

            return loggingBuilder.AddLoggerByEnvironment(serviceProvider);
        }

        public static ILoggingBuilder AddLoggerByEnvironment(this ILoggingBuilder loggingBuilder, IServiceProvider serviceProvider)
        {
            var environment = serviceProvider.GetService<IHostEnvironment>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            return loggingBuilder.AddLoggerByEnvironment(configuration, environment);
        }

        public static ILoggingBuilder AddLoggerByEnvironment(this ILoggingBuilder loggingBuilder, IConfiguration configuration, IHostEnvironment environment)
        {
            if (environment != null && !environment.IsLocal() && !environment.IsDocker())
            {
                return loggingBuilder
                        .ClearProviders()
                        .AddConsole();
            }
            else
            {
                return loggingBuilder
                        .ClearProviders()
                        .AddConsoleLogger()
                        .AddConsoleLogger(LogLevel.Warning, ConsoleColor.Yellow)
                        .AddConsoleLogger(LogLevel.Error, ConsoleColor.Red);
            }
        }

    }
}
