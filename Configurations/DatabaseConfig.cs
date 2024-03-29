using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        string? area = configuration.GetSection("AppSettings:Area")?.Value ?? throw new Exception("Area is null");
        services.AddDbContext<BaseAdminContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString($"DefaultConnection_{area}"));
            options.EnableSensitiveDataLogging(true);
        }
        );
    }
}
