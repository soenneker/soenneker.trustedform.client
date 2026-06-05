using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.TrustedForm.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.TrustedForm.Client;

///<inheritdoc cref="ITrustedFormClient"/>
public sealed class TrustedFormClient : ITrustedFormClient
{
    private readonly IHttpClientCache _httpClientCache;

    public TrustedFormClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        // No closure: static lambda with no state needed
        return _httpClientCache.Get(nameof(TrustedFormClient), static () => new HttpClientOptions(), cancellationToken);
    }

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(TrustedFormClient));
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(TrustedFormClient));
    }
}