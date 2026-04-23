using Soenneker.TrustedForm.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.TrustedForm.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class TrustedFormClientTests : HostedUnitTest
{
    private readonly ITrustedFormClient _httpclient;

    public TrustedFormClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ITrustedFormClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
