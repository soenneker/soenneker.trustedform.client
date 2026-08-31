using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.TrustedForm.Client.Abstract;

/// <summary>
/// Provides an owned, cached <see cref="HttpClient"/> transport for TrustedForm API integrations.
/// </summary>
public interface ITrustedFormClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached HTTP transport.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
