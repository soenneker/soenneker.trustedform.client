using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.TrustedForm.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.TrustedForm.Client.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for GitHub
/// </summary>
public static class TrustedFormClientRegistrar
{
    /// <summary>
    /// Adds <see cref="ITrustedFormClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTrustedFormClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ITrustedFormClient, TrustedFormClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ITrustedFormClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTrustedFormClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ITrustedFormClient, TrustedFormClient>();

        return services;
    }
}
