[![](https://img.shields.io/nuget/v/soenneker.trustedform.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.trustedform.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.trustedform.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.trustedform.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.trustedform.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.trustedform.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.trustedform.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.trustedform.client/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.TrustedForm.Client
Provides an owned, cached `HttpClient` transport for TrustedForm API integrations.

## Installation

```bash
dotnet add package Soenneker.TrustedForm.Client
```

This is the transport layer used by `Soenneker.TrustedForm.Certificates.ClientUtil`. It intentionally does not set a base URL or attach credentials; the API-specific client owns those concerns.

## Registration

```csharp
using Soenneker.TrustedForm.Client.Registrars;

services.AddTrustedFormClientAsSingleton();
```

Use `AddTrustedFormClientAsScoped()` when the transport owner should follow the current scope. Each registered owner has its own cache entry and removes that entry when disposed.

## Usage

```csharp
using Soenneker.TrustedForm.Client.Abstract;

HttpClient httpClient = await trustedFormClient.Get(cancellationToken);
```

Reuse the returned client and do not dispose it directly. `ITrustedFormClient` owns the cached transport. For authenticated Certificate API v4 calls, prefer `Soenneker.TrustedForm.Certificates.ClientUtil`, which adds the required Basic credential and API-version header.
