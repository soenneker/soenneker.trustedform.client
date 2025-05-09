using System;
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

    private const string _prodBaseUrl = "https://cert.trustedform.com/";

    public TrustedFormClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(TrustedFormClient), () =>
        {
            var options = new HttpClientOptions
            {
                BaseAddress = _prodBaseUrl,
            };
            return options;
        }, cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _httpClientCache.RemoveSync(nameof(TrustedFormClient));
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _httpClientCache.Remove(nameof(TrustedFormClient));
    }
}