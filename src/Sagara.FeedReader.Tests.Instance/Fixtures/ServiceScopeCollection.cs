using Xunit;

namespace Sagara.FeedReader.Tests.Instance.Fixtures;

[CollectionDefinition(nameof(ServiceScopeCollection))]
public class ServiceScopeCollection : ICollectionFixture<HostFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
