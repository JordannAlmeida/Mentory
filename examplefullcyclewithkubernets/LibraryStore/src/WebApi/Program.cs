using WebApi.Modules.Common;
using WebApi.Modules.Database;
using WebApi.Modules;
using WebApi.Modules.Common.FeatureFlags;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Prometheus;
using Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;

var hostBulder = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostContext, configApp) =>
        {
            configApp
            .AddCommandLine(args)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder
            .ConfigureLogging((context, builder) =>
                builder.AddLoggerByEnvironment(context))
            .UseKestrel(opt =>
            {
                opt.Limits.MaxRequestBodySize = 209715200;
            });
            webBuilder.ConfigureServices((context, services) =>
            {
                services.AddFeatureFlags(context.Configuration);
                services.AddMvc();
                services.AddVersioning();
                services.AddDatabase(context.Configuration);
                services.AddHealthChecks(context.Configuration);
                services.AddControllers();
                services.AddCustomControllers();
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen();
                services.AddMapper();
            })
            .Configure((context, app) =>
            {
                app.UseHttpsRedirection();
                app.UseCustomHttpMetrics();
                app.UseHealthChecks();
                app.UseRouting();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapMetrics();
                });
            });
        }).Build();

using (var scope = hostBulder.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabasePostgresContext>();
    db.Database.Migrate();
}

hostBulder.Run();
    