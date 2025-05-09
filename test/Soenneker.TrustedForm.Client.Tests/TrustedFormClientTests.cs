using Soenneker.TrustedForm.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.TrustedForm.Client.Tests;

[Collection("Collection")]
public class TrustedFormClientTests : FixturedUnitTest
{
    private readonly ITrustedFormClient _httpclient;

    public TrustedFormClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<ITrustedFormClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
