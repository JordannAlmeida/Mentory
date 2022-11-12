using Domain.Interfaces.Repository;
using Infraestructure.DataAccess;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Modules.Database
{
    public static class DatabasePostgresExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabasePostgresContext>(options =>
                options.UseNpgsql(GetConnectionString(configuration), b => b.MigrationsAssembly("Infraestructure")));
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            var username = configuration["databaseUser"];
            var port = configuration["databasePort"];
            var host = configuration["databaseHost"];
            var name = configuration["databaseName"];
            var password = configuration["databasePass"];
            var connection = $"Server={host}; Database={name}; Port={port}; User Id={username}; Password={password}; Pooling=true;";
            return connection;
        }
    }
}
