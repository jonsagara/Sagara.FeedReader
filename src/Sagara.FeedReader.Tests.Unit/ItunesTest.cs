using Microsoft.Extensions.DependencyInjection;
using Sagara.FeedReader.Http;
using Sagara.FeedReader.Modules.ApplePodcasts;
using Sagara.FeedReader.Tests.Unit.Fixtures;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

[Collection(nameof(ServiceScopeCollection))]
public class ItunesTest
{
    private readonly HttpClientService _httpClientSvc;

    public ItunesTest(HostFixture hostFixture)
    {
        _httpClientSvc = hostFixture.ServiceScope.ServiceProvider.GetRequiredService<HttpClientService>();
    }


    //
    // Note: these tests pull from files, which we know have the required data, so it's okay to
    //   assume that SpecificFeed is not null.
    //
    // Note: the instance-based API doesn't have synchronous methods because it reads from streams
    //   in an async fashion. Adding synchronous methods would have meant duplicating the core logic
    //   of reading from streams and deciphering encoding, which I didn't want to do. I'll reevaluate
    //   if a valid use case comes up.
    //

    [Fact]
    public async Task TestItunesSampleFeed_Async()
    {
        var feed = await FeedReader.ReadFromFileAsync("Feeds/Rss20ItunesSample.xml");

        var itunesChannel = feed.GetiTunesChannel();

        Assert.Equal("John Doe", itunesChannel.Author);

        Assert.NotNull(itunesChannel.Owner);
        Assert.Equal("John Doe", itunesChannel.Owner!.Name);
        Assert.Equal("john.doe@example.com", itunesChannel.Owner.Email);
        Assert.NotNull(itunesChannel.Image);
        Assert.Equal("http://example.com/podcasts/everything/AllAboutEverything.jpg", itunesChannel.Image!.Href);
        Assert.NotNull(itunesChannel.Categories);

        var itunesChannelCategories = itunesChannel.Categories.ToArray();
        Assert.Equal("Technology", itunesChannelCategories[0].CategoryText);
        Assert.NotNull(itunesChannelCategories[0].SubcategoryText);
        Assert.Equal("Gadgets", itunesChannelCategories[0].SubcategoryText);
        Assert.Equal("TV & Film", itunesChannelCategories[1].CategoryText);
        Assert.Equal("Arts", itunesChannelCategories[2].CategoryText);
        Assert.NotNull(itunesChannelCategories[2].SubcategoryText);
        Assert.Equal("Food", itunesChannelCategories[2].SubcategoryText);
        Assert.False(itunesChannel.Explicit);


        var item1 = feed.Items.ElementAt(0).GetiTunesItem();
        var item2 = feed.Items.ElementAt(1).GetiTunesItem();
        var item3 = feed.Items.ElementAt(2).GetiTunesItem();
        var item4 = feed.Items.ElementAt(3).GetiTunesItem();

        Assert.NotNull(item1.Image);
        Assert.Equal("http://example.com/podcasts/everything/AllAboutEverything/Episode1.jpg", item1.Image!.Href);
        Assert.NotNull(item1.Duration);
        Assert.Equal(4, item1.Duration!.Value.Seconds);
        Assert.Equal(7, item1.Duration.Value.Minutes);
        Assert.False(item1.Explicit);

        Assert.NotNull(item2.Image);
        Assert.Equal("http://example.com/podcasts/everything/AllAboutEverything/Episode2.jpg", item2.Image!.Href);
        Assert.NotNull(item2.Duration);
        Assert.Equal(34, item2.Duration!.Value.Seconds);
        Assert.Equal(4, item2.Duration.Value.Minutes);
        Assert.False(item2.Explicit);

        Assert.NotNull(item3.Image);
        Assert.Equal("http://example.com/podcasts/everything/AllAboutEverything/Episode3.jpg", item3.Image!.Href);
        Assert.NotNull(item3.Duration);
        Assert.Equal(34, item3.Duration!.Value.Seconds);
        Assert.Equal(4, item3.Duration.Value.Minutes);
        Assert.False(item3.Explicit);

        Assert.NotNull(item4.Image);
        Assert.Equal("http://example.com/podcasts/everything/AllAboutEverything/Episode4.jpg", item4.Image!.Href);
        Assert.NotNull(item4.Duration);
        Assert.Equal(59, item4.Duration!.Value.Seconds);
        Assert.Equal(3, item4.Duration.Value.Minutes);
        Assert.False(item4.Explicit);

    }
}
