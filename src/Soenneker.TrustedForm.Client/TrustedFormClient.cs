using System.Net.Http;
using System.Threading;
using System;
using System.Threading.Tasks;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.TrustedForm.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.TrustedForm.Client;

public sealed class TrustedFormClient : ITrustedFormClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly string _cacheKey = $"{nameof(TrustedFormClient)}-{Guid.NewGuid():N}";

    public TrustedFormClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(_cacheKey, static () => new HttpClientOptions(), cancellationToken);
    }

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    public void Dispose()
    {
        _httpClientCache.RemoveSync(_cacheKey);
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(_cacheKey);
    }
}
