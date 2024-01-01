using Microsoft.Extensions.DependencyInjection;
using Sagara.FeedReader.Feeds.Itunes;
using Sagara.FeedReader.Http;
using Sagara.FeedReader.Tests.Fixtures;
using Xunit;

namespace Sagara.FeedReader.Tests;

[Collection(nameof(ServiceScopeCollection))]
public class ItunesTest
{
    private readonly HttpClientService _httpClientSvc;

    public ItunesTest(HostFixture hostFixture)
    {
        _httpClientSvc = hostFixture.ServiceScope.ServiceProvider.GetRequiredService<HttpClientService>();
    }


    private void Eq(object? expected, object? actual)
    {
        Assert.Equal(expected, actual);
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
        var feed = await FeedReaderService.ReadFromFileAsync("Feeds/Rss20ItunesSample.xml");

        var itunesChannel = feed.GetItunesChannel();

        Eq("A show about everything", itunesChannel.Subtitle);
        Eq("John Doe", itunesChannel.Author);
        Eq("All About Everything is a show about everything. Each week we dive into any subject known to man and talk about it as much as we can. Look for our podcast in the Podcasts app or in the iTunes Store", itunesChannel.Summary);

        Assert.NotNull(itunesChannel.Owner);
        Eq("John Doe", itunesChannel.Owner!.Name);
        Eq("john.doe@example.com", itunesChannel.Owner.Email);
        Assert.NotNull(itunesChannel.Image);
        Eq("http://example.com/podcasts/everything/AllAboutEverything.jpg", itunesChannel.Image!.Href);
        Assert.NotNull(itunesChannel.Categories);

        var itunesChannelCategories = itunesChannel.Categories.ToArray();
        Eq("Technology", itunesChannelCategories[0].Text);
        Assert.NotNull(itunesChannelCategories[0].Children);
        Eq("Gadgets", itunesChannelCategories[0].Children.First().Text);
        Eq("TV & Film", itunesChannelCategories[1].Text);
        Eq("Arts", itunesChannelCategories[2].Text);
        Assert.NotNull(itunesChannelCategories[2].Children);
        Eq("Food", itunesChannelCategories[2].Children.First().Text);
        Eq(false, itunesChannel.Explicit);


        var item1 = feed.Items.ElementAt(0).GetItunesItem();
        var item2 = feed.Items.ElementAt(1).GetItunesItem();
        var item3 = feed.Items.ElementAt(2).GetItunesItem();
        var item4 = feed.Items.ElementAt(3).GetItunesItem();

        Eq("John Doe", item1.Author!);
        Eq("A short primer on table spices", item1.Subtitle!);
        Eq("This week we talk about <a href=\"https://itunes/apple.com/us/book/antique-trader-salt-pepper/id429691295?mt=11\">salt and pepper shakers</a>, comparing and contrasting pour rates, construction materials, and overall aesthetics. Come and join the party!", item1.Summary!);
        Assert.NotNull(item1.Image);
        Eq("http://example.com/podcasts/everything/AllAboutEverything/Episode1.jpg", item1.Image!.Href);
        Assert.NotNull(item1.Duration);
        Eq(4, item1.Duration!.Value.Seconds);
        Eq(7, item1.Duration.Value.Minutes);
        Eq(false, item1.Explicit);

        Eq("Jane Doe", item2.Author!);
        Eq("Comparing socket wrenches is fun!", item2.Subtitle!);
        Eq("This week we talk about metric vs. Old English socket wrenches. Which one is better? Do you really need both? Get all of your answers here.", item2.Summary!);
        Assert.NotNull(item2.Image);
        Eq("http://example.com/podcasts/everything/AllAboutEverything/Episode2.jpg", item2.Image!.Href);
        Assert.NotNull(item2.Duration);
        Eq(34, item2.Duration!.Value.Seconds);
        Eq(4, item2.Duration.Value.Minutes);
        Eq(false, item2.Explicit);

        Eq("Jane Doe", item3.Author!);
        Eq("Jane and Eric", item3.Subtitle!);
        Eq("This week we talk about the best Chili in the world. Which chili is better?", item3.Summary!);
        Assert.NotNull(item3.Image);
        Eq("http://example.com/podcasts/everything/AllAboutEverything/Episode3.jpg", item3.Image!.Href);
        Assert.NotNull(item3.Duration);
        Eq(34, item3.Duration!.Value.Seconds);
        Eq(4, item3.Duration.Value.Minutes);
        Eq(false, item3.Explicit);
        Eq(true, item3.IsClosedCaptioned);

        Eq("Various", item4.Author!);
        Eq("Red + Blue != Purple", item4.Subtitle!);
        Eq("This week we talk about surviving in a Red state if you are a Blue person. Or vice versa.", item4.Summary!);
        Assert.NotNull(item4.Image);
        Eq("http://example.com/podcasts/everything/AllAboutEverything/Episode4.jpg", item4.Image!.Href);
        Assert.NotNull(item4.Duration);
        Eq(59, item4.Duration!.Value.Seconds);
        Eq(3, item4.Duration.Value.Minutes);
        Eq(false, item4.Explicit);

    }
}
