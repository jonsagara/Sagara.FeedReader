using Microsoft.Extensions.DependencyInjection;
using Sagara.FeedReader.Http;
using Sagara.FeedReader.Tests.Fixtures;
using Xunit;

namespace Sagara.FeedReader.Tests;

[Collection(nameof(ServiceScopeCollection))]
public class FeedReaderTest
{
    private readonly FeedReaderService _feedReaderSvc;
    private readonly HttpClientService _httpClientSvc;

    public FeedReaderTest(HostFixture hostFixture)
    {
        _feedReaderSvc = hostFixture.ServiceScope.ServiceProvider.GetRequiredService<FeedReaderService>();
        _httpClientSvc = hostFixture.ServiceScope.ServiceProvider.GetRequiredService<HttpClientService>();
    }


    #region special cases

    [Fact]
    public async Task TestDownload400BadRequest()
    {
        // results in a 400 BadRequest if webclient is not initialized correctly
        await DownloadTestAsync("http://www.methode.at/blog?format=RSS");
    }

    [Fact]
    public async Task TestAcceptHeaderForbiddenWithParsing()
    {
        // results in 403 Forbidden if webclient does not have the accept header set
        var feed = await _feedReaderSvc.ReadAsync("http://www.girlsguidetopm.com/feed/");
        string? title = feed.Title;
        Assert.True(feed.Items.Count > 2);
        Assert.True(!string.IsNullOrEmpty(title));
    }

    [Fact]
    public async Task TestAcceptForbiddenUserAgent()
    {
        // results in 403 Forbidden if webclient does not have the accept header set
        await DownloadTestAsync("https://mikeclayton.wordpress.com/feed/");
    }


    [Fact]
    public async Task TestAcceptForbiddenUserAgentWrike()
    {
        // results in 403 Forbidden if webclient does not have the accept header set
        await DownloadTestAsync("https://www.wrike.com/blog");
    }


    #endregion

    #region ParseRssLinksFromHTML

    [Fact]
    public async Task TestParseRssLinksCodehollow()
    {
        await TestParseRssLinksAsync("https://codehollow.com", 2);
    }

    [Fact]
    public async Task TestParseRssLinksHeise()
    {
        await TestParseRssLinksAsync("http://heise.de/", 2);
    }

    [Fact]
    public async Task TestParseRssLinksHeise2()
    {
        await TestParseRssLinksAsync("heise.de", 2);
    }

    [Fact]
    public async Task TestParseRssLinksHeise3()
    {
        await TestParseRssLinksAsync("www.heise.de", 2);
    }

    [Fact]
    public async Task TestParseRssLinksNYTimes()
    {
        await TestParseRssLinksAsync("nytimes.com", 1);
    }

    private async Task TestParseRssLinksAsync(string url, int expectedNumberOfLinks)
    {
        var urls = (await _feedReaderSvc.GetFeedUrlsFromPageAsync(url))
            .Select(hfl => hfl.Url)
            .ToArray();

        Assert.Equal(expectedNumberOfLinks, urls.Length);
    }

    #endregion

    #region Parse Html and check if it returns absolute urls

    [Fact]
    public async Task TestParseAndAbsoluteUrlDerStandard1()
    {
        string url = "derstandard.at";
        var links = await _feedReaderSvc.GetFeedUrlsFromPageAsync(url);

        foreach (var link in links)
        {
            var absoluteUrl = Helpers.GetAbsoluteFeedUrl(url, link);
            Assert.StartsWith("http://", absoluteUrl.Url);
        }

    }

    #endregion

    #region Read Feed

    [Fact]
    public async Task TestReadAdobeFeed()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://blog.adobe.com/feed.xml");
        string? title = feed.Title;
        Assert.Equal("Adobe Blog", title);
    }

    [Fact]
    public async Task TestReadSimpleFeed()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://arminreiter.com/feed");
        string? title = feed.Title;
        Assert.Equal("arminreiter.com", title);
        Assert.Equal(10, feed.Items.Count());
    }

    // 2022-11-13: Feed no longer exists
    //[Fact]
    //public async Task TestReadRss20GermanFeed()
    //{
    //    var feed = await _feedReaderSvc.ReadAsync("http://guidnew.com/feed");
    //    string? title = feed.Title;
    //    Assert.Equal("Guid.New", title);
    //    Assert.True(feed.Items.Count > 0);
    //}

    [Fact]
    public async Task TestReadRss10GermanFeed()
    {
        var feed = await _feedReaderSvc.ReadAsync("http://rss.orf.at/news.xml");
        string? title = feed.Title;
        Assert.Equal("news.ORF.at", title);
        Assert.True(feed.Items.Count > 10);
    }

    [Fact]
    public async Task TestReadAtomFeedHeise()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://www.heise.de/newsticker/heise-atom.xml");
        Assert.True(!string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 1);
    }

    [Fact]
    public async Task TestReadAtomFeedGitHub()
    {
        try
        {
            var feed = await _feedReaderSvc.ReadAsync("http://github.com/codehollow/AzureBillingRateCardSample/commits/master.atom");
            //Assert.True(!string.IsNullOrEmpty(feed.Title));
        }
        catch (Exception ex)
        {
            Assert.Equal(typeof(System.Net.WebException), ex.InnerException!.GetType());
            Assert.Equal("The request was aborted: Could not create SSL/TLS secure channel.", ex.InnerException.Message);
        }

    }

    [Fact]
    public async Task TestReadRss20GermanFeedPowershell()
    {
        var feed = await _feedReaderSvc.ReadAsync("http://www.powershell.co.at/feed/");
        Assert.True(!string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadRss20FeedCharter97Handle403Forbidden()
    {
        var feed = await _feedReaderSvc.ReadAsync("charter97.org/rss.php");
        Assert.True(!string.IsNullOrEmpty(feed.Title));
    }

    [Fact]
    public async Task TestReadRssScottHanselmanWeb()
    {
        var feed = await _feedReaderSvc.ReadAsync("http://feeds.hanselman.com/ScottHanselman");
        Assert.True(!string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadBuildAzure()
    {
        await DownloadTestAsync("https://buildazure.com");
    }

    [Fact]
    public async Task TestReadNoticiasCatolicas()
    {
        var feed = await _feedReaderSvc.ReadAsync("feeds.feedburner.com/NoticiasCatolicasAleteia");
        Assert.Equal("Noticias Catolicas", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTimeDoctor()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://www.timedoctor.com/blog/feed/");
        Assert.Equal("Time Doctor Blog", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadMikeC()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://mikeclayton.wordpress.com/feed/");
        Assert.Equal("Shift Happens!", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTheLPM()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://thelazyprojectmanager.wordpress.com/feed/");
        Assert.Equal("The Lazy Project Manager's Blog", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTechRep()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://www.techrepublic.com/rssfeeds/topic/project-management/");
        Assert.Equal("Project Management Articles & Tutorials | TechRepublic", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadAPOD()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://apod.nasa.gov/apod.rss");
        Assert.Equal("APOD", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadThaqafnafsak()
    {
        var feed = await _feedReaderSvc.ReadAsync("http://www.thaqafnafsak.com/feed");
        Assert.Equal("ثقف نفسك", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    // 2023-07-26: Feed no longer exists
    //[Fact]
    //public async Task TestReadTheStudentLawyer()
    //{
    //    var feed = await _feedReaderSvc.ReadAsync("http://us10.campaign-archive.com/feed?u=8da2e137a07b178e5d9a71c2c&id=9134b0cc95");
    //    Assert.Equal("The Student Lawyer Careers Network Archive Feed", feed.Title);
    //    Assert.True(feed.Items.Count > 0);
    //}

    [Fact]
    public async Task TestReadLiveBold()
    {
        var feed = await _feedReaderSvc.ReadAsync("http://feeds.feedburner.com/LiveBoldAndBloom");
        Assert.Equal("Live Bold and Bloom", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestSwedish_ISO8859_1()
    {
        var feed = await _feedReaderSvc.ReadAsync("https://www.retriever-info.com/feed/2004645/intranet30/index.xml");
        Assert.Equal("intranet30", feed.Title);
    }

    [Fact]
    public async Task TestStadtfeuerwehrWeiz_ISO8859_1()
    {
        var feed = await _feedReaderSvc.ReadAsync("http://www.stadtfeuerwehr-weiz.at/rss/einsaetze.xml");
        Assert.Equal("Stadtfeuerwehr Weiz - Einsätze", feed.Title);
    }
    #endregion

    #region private helpers

    private async Task DownloadTestAsync(string url)
    {
        var content = await _httpClientSvc.DownloadStringAsync(url);
        Assert.True(content.Length > 200);
    }

    #endregion
}
