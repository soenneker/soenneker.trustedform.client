﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.TrustedForm.Client.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface ITrustedFormClient: IDisposable, IAsyncDisposable
{
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
