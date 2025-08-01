﻿using System.Net.Http;
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
        return _httpClientCache.Get(nameof(TrustedFormClient), () =>
        {
            var options = new HttpClientOptions();

            return options;
        }, cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(TrustedFormClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(TrustedFormClient));
    }
}