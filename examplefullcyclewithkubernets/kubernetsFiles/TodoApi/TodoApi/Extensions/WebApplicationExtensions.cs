using Microsoft.EntityFrameworkCore;
using TodoApi.Database;

namespace TodoApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                var appContext = scope.ServiceProvider.GetRequiredService<TodoContext>();
                appContext.Database.Migrate();
            }

            return webApp;
        }
    }
}
