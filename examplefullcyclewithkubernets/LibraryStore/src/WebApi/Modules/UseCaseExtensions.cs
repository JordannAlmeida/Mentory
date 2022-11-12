using Application.UseCases.Books;

namespace WebApi.Modules
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IGetCountAllBooksUseCase, GetCountAllBooksUseCase>();
            
            return services;
        }
    }
}
