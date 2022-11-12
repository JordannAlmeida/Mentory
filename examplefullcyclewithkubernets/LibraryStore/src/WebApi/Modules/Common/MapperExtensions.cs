using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApi.Modules.Common
{
    public static class MapperExtensions
    {
        public static void AddMapper(this IServiceCollection services, bool validarMapeamento = false)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            if (validarMapeamento)
            {
                var mapper = services.BuildServiceProvider().GetRequiredService<IMapper>();
                mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }
        }
    }
}