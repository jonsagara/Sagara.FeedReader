using Microsoft.Extensions.DependencyInjection;
using Sagara.FeedReader.Feeds;
using Sagara.FeedReader.Http;
using Sagara.FeedReader.Modules.ApplePodcasts;
using Sagara.FeedReader.Tests.Unit.Fixtures;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

[Collection(nameof(ServiceScopeCollection))]
public class FullParseTest
{
    private readonly HttpClientService _httpClientSvc;

    public FullParseTest(HostFixture hostFixture)
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
    public async Task TestAtomParseAdobe_Async()
    {
        var feed = (AtomFeed)(await FeedReader.ReadFromFileAsync("Feeds/AtomAdobe.xml")).SpecificFeed!;

        Assert.Equal("Adobe Blog", feed.Title);
        Assert.Null(feed.Icon);
        Assert.Equal("https://blog.adobe.com/", feed.Link);
        Assert.Equal("2021-07-19T00:00:00.000Z", feed.UpdatedDateString);
        Assert.Equal("https://blog.adobe.com/", feed.Id);

        var item = (AtomFeedItem)feed.Items.First();
        Assert.Null(item.Link); // The post href is store in the id element
    }

    [Fact]
    public async Task TestAtomParseTheVerge_Async()
    {
        var feed = (AtomFeed)(await FeedReader.ReadFromFileAsync("Feeds/AtomTheVerge.xml")).SpecificFeed!;

        Assert.Equal("The Verge -  Front Pages", feed.Title);
        Assert.Equal("https://cdn2.vox-cdn.com/community_logos/34086/verge-fv.png", feed.Icon);
        Assert.Equal("2017-01-07T09:00:01-05:00", feed.UpdatedDateString);
        Assert.Equal(new DateTime(2017, 1, 7, 14, 0, 1), feed.UpdatedDate);
        Assert.Equal("http://www.theverge.com/rss/group/front-page/index.xml", feed.Id);

        var item = (AtomFeedItem)feed.Items.First();

        Assert.Equal("2017-01-07T09:00:01-05:00", item.UpdatedDateString);
        Assert.Equal(new DateTime(2017, 1, 7, 14, 0, 1), item.UpdatedDate);
        Assert.Equal("2017-01-07T09:00:01-05:00", item.PublishedDateString);
        Assert.Equal(new DateTime(2017, 1, 7, 14, 0, 1), item.PublishedDate);
        Assert.Equal("This is the new Hulu experience with live TV", item.Title);
        Assert.Equal("http://www.theverge.com/ces/2017/1/7/14195588/hulu-live-tv-streaming-internet-ces-2017", item.Id);
        Assert.Equal("http://www.theverge.com/ces/2017/1/7/14195588/hulu-live-tv-streaming-internet-ces-2017", item.Link);

        Assert.StartsWith("<img alt=\"\"", item.Content!.Trim());

        Assert.Equal("Chris Welch", item.Author!.Name);
    }

    [Fact]
    public async Task TestAtomYouTubeInvestmentPunk_Async()
    {
        var feed = (AtomFeed)(await FeedReader.ReadFromFileAsync("Feeds/AtomYoutubeInvestmentPunk.xml")).SpecificFeed!;

        Assert.Equal("http://www.youtube.com/feeds/videos.xml?channel_id=UCmEN5ZnsHUXIxgpLitRTmWw", feed.Links.First().Href);
        Assert.Equal("yt:channel:UCmEN5ZnsHUXIxgpLitRTmWw", feed.Id);
        Assert.Equal("Investment Punk Academy by Gerald Hörhan", feed.Title);
        Assert.Equal("http://www.youtube.com/channel/UCmEN5ZnsHUXIxgpLitRTmWw", feed.Links.ElementAt(1).Href);
        Assert.Equal("Investment Punk Academy by Gerald Hörhan", feed.Author!.Name);
        Assert.Equal("http://www.youtube.com/channel/UCmEN5ZnsHUXIxgpLitRTmWw", feed.Author.Uri);
        var item = (AtomFeedItem)feed.Items.First();
        Assert.Equal("yt:video:AFA8ZtMwrvc", item.Id);
        Assert.Equal("Zukunft von Vertretern I Kernfusion I Musikgeschäft #ASKTHEPUNK 71", item.Title);
        Assert.Equal("alternate", item.Links.First().Relation);
        Assert.Equal("2017-01-23T18:14:49+00:00", item.UpdatedDateString);
        Assert.Equal("2017-01-20T16:00:00+00:00", item.PublishedDateString);
    }

    [Fact]
    public async Task TestRss091ParseStadtFWeiz_Async()
    {
        var feed = (Rss091Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss091Stadtfeuerwehr.xml")).SpecificFeed!;

        Assert.Equal("Stadtfeuerwehr Weiz - Einsätze", feed.Title);
        Assert.Equal("http://www.stadtfeuerwehr-weiz.at", feed.Link);
        Assert.Equal("Die letzten 15 Einsätze der Stadtfeuerwehr Weiz.", feed.Description);
        Assert.Equal("de-de", feed.Language);
        Assert.Equal("Stadtfeuerwehr Weiz / Markus Horwath", feed.Copyright);

        var item = (Rss091FeedItem)feed.Items.First();

        Assert.Equal(@"[19.08.2018 - 07:08 Uhr] Brandmeldeanlagenalarm", item.Title!.Trim());
        Assert.Contains("Weitere Informationen", item.Description);
        Assert.Equal("http://www.stadtfeuerwehr-weiz.at/einsaetze/einsatz-detail/5220/", item.Link);
        Assert.Equal("Sun, 19 Aug 2018 07:08:00 +0100", item.PublishingDateString);
        Assert.Equal(new DateTime(2018, 8, 19, 6, 08, 0), item.PublishingDate);

        Assert.Equal(15, feed.Items.Count);
    }

    [Fact]
    public async Task TestRss091ParseFullSample_Async()
    {
        var feed = (Rss091Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss091FullSample.xml")).SpecificFeed!;
        Assert.Equal("Copyright 1997-1999 UserLand Software, Inc.", feed.Copyright);
        Assert.Equal("Thu, 08 Jul 1999 07:00:00 GMT", feed.PublishingDateString);
        Assert.Equal("Thu, 08 Jul 1999 16:20:26 GMT", feed.LastBuildDateString);
        Assert.Equal("http://my.userland.com/stories/storyReader$11", feed.Docs);
        Assert.Equal("News and commentary from the cross-platform scripting community.", feed.Description);
        Assert.Equal("http://www.scripting.com/", feed.Link);
        Assert.Equal("Scripting News", feed.Title);
        Assert.Equal("http://www.scripting.com/", feed.Image!.Link);
        Assert.Equal("Scripting News", feed.Image.Title);
        Assert.Equal("http://www.scripting.com/gifs/tinyScriptingNews.gif", feed.Image.Url);
        Assert.Equal(40, ((Rss091FeedImage)feed.Image).Height);
        Assert.Equal(78, ((Rss091FeedImage)feed.Image).Width);
        Assert.Equal("What is this used for?", ((Rss091FeedImage)feed.Image).Description);
        Assert.Equal("dave@userland.com (Dave Winer)", feed.ManagingEditor);
        Assert.Equal("dave@userland.com (Dave Winer)", feed.WebMaster);
        Assert.Equal("en-us", feed.Language);
        Assert.Contains("6", feed.SkipHours);
        Assert.Contains("7", feed.SkipHours);
        Assert.Contains("8", feed.SkipHours);
        Assert.Contains("9", feed.SkipHours);
        Assert.Contains("10", feed.SkipHours);
        Assert.Contains("11", feed.SkipHours);
        Assert.Contains("Sunday", feed.SkipDays);
        Assert.Equal("(PICS-1.1 \"http://www.rsac.org/ratingsv01.html\" l gen true comment \"RSACi North America Server\" for \"http://www.rsac.org\" on \"1996.04.16T08:15-0500\" r (n 0 s 0 v 0 l 0))", feed.Rating);

        Assert.Single(feed.Items);
        var item = (Rss091FeedItem)feed.Items.First();
        Assert.Equal("stuff", item.Title);
        Assert.Equal("http://bar", item.Link);
        Assert.Equal("This is an article about some stuff", item.Description);

        Assert.Equal("Search Now!", feed.TextInput!.Title);
        Assert.Equal("Enter your search terms", feed.TextInput.Description);
        Assert.Equal("find", feed.TextInput.Name);
        Assert.Equal("http://my.site.com/search.cgi", feed.TextInput.Link);
    }

    [Fact]
    public async Task TestRss092ParseFullSample_Async()
    {
        var feed = (Rss092Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss092FullSample.xml")).SpecificFeed!;

        Assert.Equal("Dave Winer: Grateful Dead", feed.Title);
        Assert.Equal("http://www.scripting.com/blog/categories/gratefulDead.html", feed.Link);
        Assert.Equal("A high-fidelity Grateful Dead song every day. This is where we're experimenting with enclosures on RSS news items that download when you're not using your computer. If it works (it will) it will be the end of the Click-And-Wait multimedia experience on the Internet. ", feed.Description);
        Assert.Equal("Fri, 13 Apr 2001 19:23:02 GMT", feed.LastBuildDateString);
        Assert.Equal("http://backend.userland.com/rss092", feed.Docs);
        Assert.Equal("dave@userland.com (Dave Winer)", feed.ManagingEditor);
        Assert.Equal("dave@userland.com (Dave Winer)", feed.WebMaster);
        Assert.Equal("data.ourfavoritesongs.com", feed.Cloud!.Domain);
        Assert.Equal("80", feed.Cloud.Port);
        Assert.Equal("/RPC2", feed.Cloud.Path);
        Assert.Equal("ourFavoriteSongs.rssPleaseNotify", feed.Cloud.RegisterProcedure);
        Assert.Equal("xml-rpc", feed.Cloud.Protocol);

        Assert.Equal(22, feed.Items.Count);
        var item = (Rss092FeedItem)feed.Items.ElementAt(20);
        Assert.Equal("A touch of gray, kinda suits you anyway..", item.Description);
        Assert.Equal("http://www.scripting.com/mp3s/touchOfGrey.mp3", item.Enclosure!.Url);
        Assert.Equal(5588242, item.Enclosure.Length);
        Assert.Equal("audio/mpeg", item.Enclosure.MediaType);

        var secondItem = (Rss092FeedItem)feed.Items.ElementAt(1);
        Assert.Equal("http://scriptingnews.userland.com/xml/scriptingNews2.xml", secondItem.Source!.Url);
        Assert.Equal("Scripting News", secondItem.Source.Value);
    }

    [Fact]
    public async Task TestRss10ParseFullSample_Async()
    {
        var feed = (Rss10Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss10FeedWebResourceSample.xml")).SpecificFeed!;

        Assert.Equal("XML.com", feed.Title);
        Assert.Equal("http://xml.com/pub", feed.Link);
        Assert.Equal("\n      XML.com features a rich mix of information and services\n      for the XML community.\n    ", feed.Description);
        var image = (Rss10FeedImage)feed.Image!;
        Assert.Equal("http://xml.com/universal/images/xml_tiny.gif", image.About);
        Assert.Equal("XML.com", image.Title);
        Assert.Equal("http://www.xml.com", image.Link);
        Assert.Equal("http://xml.com/universal/images/xml_tiny.gif", image.Url);
        Assert.Equal("Search XML.com", feed.TextInput!.Title);
        Assert.Equal("Search XML.com's XML collection", feed.TextInput.Description);
        Assert.Equal("s", feed.TextInput.Name);
        Assert.Equal("http://search.xml.com", ((Rss10FeedTextInput)feed.TextInput).About);
        Assert.Equal("http://search.xml.com", feed.TextInput.Link);

        var item = (Rss10FeedItem)feed.Items.Last();

        Assert.Equal("http://xml.com/pub/2000/08/09/rdfdb/index.html", item.About);
        Assert.Equal("Putting RDF to Work", item.Title);
        Assert.Equal("http://xml.com/pub/2000/08/09/rdfdb/index.html", item.Link);
        Assert.Equal(186, item.Description!.Length);
    }

    [Fact]
    public async Task TestRss10ParseOrfAt_Async()
    {
        var feed = (Rss10Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss10OrfAt.xml")).SpecificFeed!;
        Assert.Equal("news.ORF.at", feed.Title);
        Assert.Equal("http://orf.at/", feed.Link);
        Assert.Equal("2017-01-23T21:54:55+01:00", feed.DC!.DateString);
        Assert.Equal("Die aktuellsten Nachrichten auf einen Blick - aus Österreich und der ganzen Welt. In Text, Bild und Video.", feed.Description);
        Assert.Equal("ORF Österreichischer Rundfunk, Wien", feed.DC.Publisher);
        Assert.Equal("ORF Online und Teletext GmbH & Co KG", feed.DC.Creator);
        Assert.Equal("de", feed.DC.Language);
        Assert.Equal("Copyright © 2017 ORF Online und Teletext GmbH & Co KG", feed.DC.Rights);
        Assert.Equal("hourly", feed.Sy!.UpdatePeriod);
        Assert.Equal("2", feed.Sy.UpdateFrequency);
        Assert.Equal("2000-01-01T00:00:00Z", feed.Sy.UpdateBase);
        Assert.Equal(50, feed.Items.Count);

        var item = (Rss10FeedItem)feed.Items.ElementAt(4);

        Assert.Equal("Feldsperling erstmals häufigster Vogel", item.Title);
        Assert.Equal("http://orf.at/stories/2376365/", item.Link);
        Assert.Equal("Chronik", item.DC!.Subject);
        Assert.Equal("2017-01-23T20:51:06+01:00", item.DC.DateString);
    }

    [Fact]
    public async Task TestRss20ParseWebResourceSampleFull_Async()
    {
        var feed = (Rss20Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss20FeedWebResourceSample.xml")).SpecificFeed!;

        Assert.Equal("Scripting News", feed.Title);
        Assert.Equal("http://www.scripting.com/", feed.Link);
        Assert.Equal("A weblog about scripting and stuff like that.", feed.Description);
        Assert.Equal("en-us", feed.Language);
        Assert.Equal("Copyright 1997-2002 Dave Winer", feed.Copyright);
        Assert.Equal("Mon, 30 Sep 2002 11:00:00 GMT", feed.LastBuildDateString);
        Assert.Equal("http://backend.userland.com/rss", feed.Docs);
        Assert.Equal("Radio UserLand v8.0.5", feed.Generator);
        Assert.Equal("1765", feed.Categories.First());
        Assert.Equal("dave@userland.com", feed.ManagingEditor);
        Assert.Equal("dave@userland.com", feed.WebMaster);
        Assert.Equal("40", feed.TTL);
        Assert.Equal(9, feed.Items.Count);

        var item = (Rss20FeedItem)feed.Items.Last();
        Assert.Equal("Really early morning no-coffee notes", item.Title);
        Assert.Equal("http://scriptingnews.userland.com/backissues/2002/09/29#reallyEarlyMorningNocoffeeNotes", item.Link);
        Assert.Contains("<p>One of the lessons I've learned", item.Description);
        Assert.Equal("Sun, 29 Sep 2002 11:13:10 GMT", item.PublishingDateString);
        Assert.Equal(new DateTime(2002, 09, 29, 11, 13, 10), item.PublishingDate);
        Assert.Equal("http://scriptingnews.userland.com/backissues/2002/09/29#reallyEarlyMorningNocoffeeNotes", item.Guid);
    }

    [Fact]
    public async Task TestRss20ParseCodeHollow_Async()
    {
        var feed = (Rss20Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss20CodeHollowCom.xml")).SpecificFeed!;

        Assert.Equal("codehollow", feed.Title);
        Assert.Equal("https://codehollow.com", feed.Link);
        Assert.Equal("Azure, software engineering/architecture, Scrum, SharePoint, VSTS/TFS, .NET and other funny things", feed.Description);
        Assert.Equal("Fri, 23 Dec 2016 09:01:55 +0000", feed.LastBuildDateString);
        Assert.Equal(new DateTime(2016, 12, 23, 09, 01, 55), feed.LastBuildDate);
        Assert.Equal("en-US", feed.Language);
        Assert.Equal("hourly", feed.Sy!.UpdatePeriod);
        Assert.Equal("1", feed.Sy.UpdateFrequency);
        Assert.Equal("https://wordpress.org/?v=4.7", feed.Generator);

        var item = (Rss20FeedItem)feed.Items.First();

        Assert.Equal("Export Azure RateCard data to CSV with C# and Billing API", item.Title);
        Assert.Equal("https://codehollow.com/2016/12/export-azure-ratecard-data-csv-csharp-billing-api/", item.Link);
        Assert.Equal("https://codehollow.com/2016/12/export-azure-ratecard-data-csv-csharp-billing-api/#respond", item.Comments);
        Assert.Equal("Thu, 22 Dec 2016 07:00:28 +0000", item.PublishingDateString);
        Assert.Equal(new DateTime(2016, 12, 22, 7, 0, 28), item.PublishingDate);
        Assert.Equal("Armin Reiter", item.DC!.Creator);
        Assert.Equal(4, item.Categories.Count);
        Assert.Contains("BillingAPI", item.Categories);
        Assert.Equal("https://codehollow.com/?p=749", item.Guid);
        Assert.StartsWith("<p>The Azure Billing API allows to programmatically read Azure", item.Description);
        Assert.Contains("<add key=\"Tenant\" ", item.Content);

    }

    [Fact]
    public async Task TestRss20ParseContentWindGerman_Async()
    {
        var feed = (Rss20Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss20ContentWindCom.xml")).SpecificFeed!;
        Assert.Equal("ContentWind", feed.Title);
        Assert.Equal("http://content-wind.com", feed.Link);
        Assert.Equal("Do, 22 Dez 2016 17:36:00 +0000", feed.LastBuildDateString);
        Assert.Equal(new DateTime(2016, 12, 22, 17, 36, 00), feed.LastBuildDate);
        Assert.Equal("de-DE", feed.Language);
        Assert.Equal("hourly", feed.Sy!.UpdatePeriod);
        Assert.Equal("1", feed.Sy.UpdateFrequency);
        Assert.Equal("https://wordpress.org/?v=4.7", feed.Generator);

        var item = (Rss20FeedItem)feed.Items.First();
        Assert.Equal("Wachstum Influencer Marketing", item.Title);
        Assert.Equal("http://content-wind.com/2016/12/22/wachstum-influencer-marketing/", item.Link);
        Assert.Equal("http://content-wind.com/2016/12/22/wachstum-influencer-marketing/#respond", item.Comments);
        Assert.Equal("Thu, 22 Dec 2016 13:09:51 +0000", item.PublishingDateString);
        Assert.Equal(new DateTime(2016, 12, 22, 13, 09, 51), item.PublishingDate);
        Assert.Equal("Harald Schaffernak", item.DC!.Creator);

    }

    [Fact]
    public async Task TestRss20ParseMoscowTimes_Async()
    {
        var feed = (Rss20Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss20MoscowTimes.xml")).SpecificFeed!;
        Assert.Equal("The Moscow Times - News, Business, Culture & Multimedia from Russia", feed.Title);
        Assert.Equal("https://themoscowtimes.com/", feed.Link);
        Assert.Equal("The Moscow Times offers everything you need to know about Russia: Breaking news, top stories, business, analysis, opinion, multimedia, upcoming cultural events", feed.Description);
        Assert.Equal("en-us", feed.Language);
        Assert.Equal("Mon, 23 Jan 2017 16:45:02 +0000", feed.LastBuildDateString);
        Assert.Equal("600", feed.TTL);

        var item = (Rss20FeedItem)feed.Items.First();
        Assert.Equal("Russian State TV Praises Trump for Avoiding ‘Democracy’ in Inauguration Speech", item.Title);
        Assert.Equal("https://themoscowtimes.com/articles/russian-state-tv-praises-trump-for-avoiding-democracy-in-inauguration-speech-56901", item.Link);
        Assert.Equal("Though he welcomed the end of Obama’s presidency as the start of a bright new era, the Kremlin’s “chief propagandist” quickly found himself struggling to find convincing scapegoats for the world’s problems this week.", item.Description);
        Assert.Equal("Mon, 23 Jan 2017 16:45:02 +0000", item.PublishingDateString);
        Assert.Equal("https://themoscowtimes.com/articles/russian-state-tv-praises-trump-for-avoiding-democracy-in-inauguration-speech-56901", item.Guid);

        item = (Rss20FeedItem)feed.Items.Last();
        Assert.Equal("Don’t Say It", item.Title);
        Assert.Equal("https://themoscowtimes.com/articles/dont-say-it-56774", item.Link);
        Assert.Equal("They say “sex sells,” but don't go peddling it near dinner tables in Russia, where families in an ostensibly conservative society say the subject is too taboo to discuss at home.", item.Description);
        Assert.Equal("Tue, 10 Jan 2017 19:58:13 +0000", item.PublishingDateString);
        Assert.Equal("https://themoscowtimes.com/articles/dont-say-it-56774", item.Guid);
    }

    [Fact]
    public async Task TestRss20ParseSwedishFeedWithIso8859_1_Async()
    {
        var feed = (Rss20Feed)(await FeedReader.ReadFromFileAsync("Feeds/Rss20ISO88591Intranet30.xml")).SpecificFeed!;
        Assert.Equal("intranet30", feed.Title);
        Assert.Equal("http://www.retriever-info.com", feed.Link);
        Assert.Equal("RSS 2.0 News feed from Retriever Norge AS", feed.Description);

        var item = (Rss20FeedItem)feed.Items.First();
        Assert.Equal("SVART MÅNAD - DÖDSOLYCKA i Vetlanda", item.Title);
        Assert.Equal("https://www.retriever-info.com/go/?a=30338&d=00201120180819281555686&p=200108&s=2011&sa=2016177&u=http%3A%2F%2Fwww.hoglandsnytt.se%2Fsvart-manad-dodsolycka-i-vetlanda%2F&x=33d88e677ce6481d9882de22c76e4234", item.Link);
        Assert.Equal("Under juli 2018 omkom 39 personer och 1 521 skadades i vägtrafiken. Det visar de preliminära uppgifter som inkommit till Transportstyrelsen fram till den 15 augusti 2018. Det är åtta fler omkomna jämfört med juli månad 2017.", item.Description);
        Assert.Equal("Sun, 19 Aug 2018 07:14:00 GMT", item.PublishingDateString);
        Assert.Equal("00201120180819281555686", item.Guid);
        Assert.Equal("Höglandsnytt", item.Author);
    }

    [Fact]
    public async Task TestRss20CityDogKyrillicNoEncodingDefined_Async()
    {
        var feed = await FeedReader.ReadFromFileAsync("Feeds/Rss20CityDog.xml");
        Assert.Equal("Новости - citydog.by", feed.Title);
        Assert.Equal("Последние обновления - citydog.by", feed.Description);

        var item = feed.Items.First();
        Assert.Equal("Группа «Серебряная свадьба» ушла в бессрочный отпуск", item.Title);
        Assert.Equal("http://citydog.by/post/zaden-serebrianaya-svadba-v-otpuske/", item.Id);
    }

    [Fact]
    public async Task TestAllFilesForException_Async()
    {
        var linkless = new List<string>() { "AtomBattleNet.xml" };

        var files = Directory.EnumerateFiles("Feeds");
        foreach (var file in files)
        {
            var feed = await FeedReader.ReadFromFileAsync(file);
            if (feed is not null)
            {
                string filename = Path.GetFileName(file);
                if (!linkless.Contains(filename))
                {
                    Assert.True(!string.IsNullOrEmpty(feed.Link));
                }

                TestApplePodcastsParsingForException(feed);
            }
        }
    }


    //
    // Private methods
    //

    private static void TestApplePodcastsParsingForException(Feed feed)
    {
        Assert.NotNull(feed.GetiTunesChannel());

        foreach (var item in feed.Items)
        {
            Assert.NotNull(item.GetiTunesItem());
        }
    }
}
