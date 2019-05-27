using AutoMapper;
using Lantern.Api.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Lantern.Api.DependencyInjection
{
    public static class ConfigureMapperExtensions
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            Mapper.Initialize(cfg => cfg.AddMaps(typeof(ResponseModelMapperProfile).Assembly));
            services.AddAutoMapper(typeof(ResponseModelMapperProfile));
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(m => new Mapper(m.GetRequiredService<IConfigurationProvider>(), m.GetService));

            return services;
        }
    }
}