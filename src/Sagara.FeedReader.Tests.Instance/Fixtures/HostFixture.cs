using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sagara.FeedReader.Extensions;

namespace Sagara.FeedReader.Tests.Instance.Fixtures;

public class HostFixture : IDisposable
{
    private readonly IHost _host;
    public IServiceScope ServiceScope { get; }

    public HostFixture()
    {
        _host = new HostBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();

        ServiceScope = _host.Services.CreateScope();
    }

    public void Dispose()
    {
        ServiceScope.Dispose();
        _host.Dispose();
    }


    //
    // Private methods
    //

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddFeedReaderServices();
    }
}
