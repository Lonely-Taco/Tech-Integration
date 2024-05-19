using TechIntegration.Client.Client;
using TechIntegration.Core.Parser;

namespace TechIntegration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
      

        services.AddScoped<IClient, Client.Client.Client>();
        services.AddScoped<ICsvParse, Parser>();

        return services;
    }
}