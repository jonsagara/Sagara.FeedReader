using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Tests.Unit.Fixtures;

public class HostFixture : IDisposable
{
    private readonly IHost _host;
    public IServiceScope ServiceScope { get; }

    public HostFixture()
    {
        var builder = new HostApplicationBuilder();
        builder.Services.AddFeedReaderServices();

        _host = builder.Build();

        ServiceScope = _host.Services.CreateScope();
    }

    public void Dispose()
    {
        ServiceScope.Dispose();
        _host.Dispose();
    }
}
