namespace WebApi.Modules.Common
{
    public static class HostEnvironmentExtensions
    {
        public static bool IsLocal(this IHostEnvironment environment) => environment.IsEnvironment("Local") || environment.IsEnvironment("WSL");

        public static bool IsDocker(this IHostEnvironment environment) => environment.IsEnvironment("Docker");
    }
}
