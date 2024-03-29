using API.Helpers.AutoMapper;
using AutoMapper;

namespace API.Configurations;

public static class AutoMapperRegisterConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IMapper>(sp =>
        {
            return new Mapper(AutoMapperConfig.RegisterMappings());
        });

        services.AddSingleton(AutoMapperConfig.RegisterMappings());
    }
}