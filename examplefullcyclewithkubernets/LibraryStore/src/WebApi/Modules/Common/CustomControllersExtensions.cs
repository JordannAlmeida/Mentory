namespace WebApi.Modules.Common
{
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    ///     Custom Controller Extensions.
    /// </summary>
    public static class CustomControllersExtensions
    {
        /// <summary>
        ///     Add Custom Controller dependencies.
        /// </summary>
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            var environment = services.BuildServiceProvider().GetRequiredService<IHostEnvironment>();

            services
                .AddHttpContextAccessor()
                .AddControllers(options =>
                {
                    options.OutputFormatters.RemoveType<TextOutputFormatter>();
                    options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                    options.RespectBrowserAcceptHeader = true;
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddControllersAsServices();

            return services;
        }
    }
}