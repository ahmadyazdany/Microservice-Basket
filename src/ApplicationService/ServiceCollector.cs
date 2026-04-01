using Microsoft.Extensions.DependencyInjection;
namespace ApplicationService;

public static class ServiceCollector
{
    public static IServiceCollection RegisterHandlers(this IServiceCollection services)
    { 
        return services;
    }
}
