using Microsoft.EntityFrameworkCore;
using Valhalla.Application.Data;

namespace Valhalla.Api.ServiceExtensions;

public static class DbContextServiceExtension
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ValhallaDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}