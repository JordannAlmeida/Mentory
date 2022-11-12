namespace TodoApi.Database.Configurations
{
    public static class DatabaseHelper
    {
        public static string GetStringConnection(IConfiguration configuration)
        {
            return $"Server={configuration["hostDatabase"]}; Port={configuration["portDatabase"]}; Database={configuration["database"]}; User Id={configuration["userDatabase"]}; Password={configuration["passDatabase"]}; Pooling = true;";
        }
    }
}
