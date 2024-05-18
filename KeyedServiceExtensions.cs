using System.Collections.Concurrent;

namespace TechIntegration;

public static class KeyedServiceExtensions
{
    private static readonly ConcurrentDictionary<string, Type> KeyedServices = new();

    public static IServiceCollection AddKeyedSingleton<TService, TImplementation>(
        this IServiceCollection services,
        string key
    )
    where TService : class
    where TImplementation : class, TService
    {
        KeyedServices[key] = typeof(TImplementation);
        services.AddSingleton<TImplementation>();
        services.AddSingleton<Func<string, TService>>(
            sp => k =>
            {
                if (KeyedServices.TryGetValue(k, out var implementationType))
                {
                    return (TService)sp.GetRequiredService(implementationType);
                }

                throw new ArgumentException($"Service for key '{k}' not found.");
            }
        );
        return services;
    }
}