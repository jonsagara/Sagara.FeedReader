using Microsoft.Extensions.DependencyInjection;
using Sagara.FeedReader.Http;
using Sagara.FeedReader.Tests.Integration.Fixtures;
using Xunit;

namespace Sagara.FeedReader.Tests.Integration;

[Collection(nameof(ServiceScopeCollection))]
public class FeedReaderTest
{
    private readonly FeedReader _feedReaderSvc;
    private readonly HttpClientService _httpClientSvc;

    public FeedReaderTest(HostFixture hostFixture)
    {
        _feedReaderSvc = hostFixture.ServiceScope.ServiceProvider.GetRequiredService<FeedReader>();
        _httpClientSvc = hostFixture.ServiceScope.ServiceProvider.GetRequiredService<HttpClientService>();
    }


    #region special cases

    // 2026-11-14: Removed TestDownload400BadRequest. http://www.methode.at/blog?format=RSS now returns 404,
    //   and the test only passed because DownloadTestAsync doesn't check the status code.

    [Fact]
    public async Task TestAcceptHeaderForbiddenWithParsing()
    {
        // results in 403 Forbidden if webclient does not have the accept header set
        var feed = await _feedReaderSvc.ReadFromUrlAsync("http://www.girlsguidetopm.com/feed/", cancellationToken: TestContext.Current.CancellationToken);
        string? title = feed.Title;
        Assert.True(feed.Items.Count > 2);
        Assert.True(!string.IsNullOrEmpty(title));
    }

    [Fact]
    public async Task TestAcceptForbiddenUserAgent()
    {
        // results in 403 Forbidden if webclient does not have the accept header set
        await DownloadTestAsync("https://mikeclayton.wordpress.com/feed/", TestContext.Current.CancellationToken);
    }


    [Fact]
    public async Task TestAcceptForbiddenUserAgentWrike()
    {
        // results in 403 Forbidden if webclient does not have the accept header set
        await DownloadTestAsync("https://www.wrike.com/blog", TestContext.Current.CancellationToken);
    }


    #endregion

    #region ParseRssLinksFromHTML

    [Fact]
    public async Task TestParseRssLinksCodehollow()
    {
        await TestParseRssLinksAsync("https://codehollow.com", 2, TestContext.Current.CancellationToken);
    }

    // 2026-11-14: Removed TestParseRssLinksNYTimes. nytimes.com intermittently returns a 403 bot-block page,
    //   which (without a status code check) shows up as zero links.

    [Fact]
    public async Task TestParseRssLinksTechMeme()
    {
        await TestParseRssLinksAsync("https://techmeme.com/", 2, TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task TestParseRssLinksTechMemeNakedDomain()
    {
        await TestParseRssLinksAsync("techmeme.com", 2, TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task TestParseRssLinksTechMemeWwwDomain()
    {
        await TestParseRssLinksAsync("www.techmeme.com", 2, TestContext.Current.CancellationToken);
    }

    private async Task TestParseRssLinksAsync(string url, int expectedNumberOfLinks, CancellationToken cancellationToken = default)
    {
        var urls = (await _feedReaderSvc.GetFeedUrlsFromPageAsync(url, cancellationToken))
            .Select(hfl => hfl.Url)
            .ToArray();

        Assert.Equal(expectedNumberOfLinks, urls.Length);
    }

    #endregion

    // 2026-11-14: Removed TestParseAndAbsoluteUrlDerStandard1. derstandard.at no longer has any feed <link> tags,
    //   so the loop never ran and the test passed vacuously. Absolute URL resolution will be covered by unit tests
    //   when GetFeedUrlsFromPageAsync starts returning absolute URLs.

    #region Read Feed

    // 2026-11-14: Removed TestReadAdobeFeed. https://blog.adobe.com/feed.xml now returns a 404 HTML page.
    //   Atom parsing of the Adobe feed is still covered by the AtomAdobe.xml unit test fixture.

    [Fact]
    public async Task TestReadSimpleFeed()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("https://arminreiter.com/feed", cancellationToken: TestContext.Current.CancellationToken);
        string? title = feed.Title;
        Assert.Equal("arminreiter.com", title);
        Assert.NotEmpty(feed.Items);
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
        var feed = await _feedReaderSvc.ReadFromUrlAsync("http://rss.orf.at/news.xml", cancellationToken: TestContext.Current.CancellationToken);
        string? title = feed.Title;
        Assert.Equal("news.ORF.at", title);
        Assert.True(feed.Items.Count > 10);
    }

    [Fact]
    public async Task TestReadAtomFeedHeise()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("https://www.heise.de/newsticker/heise-atom.xml", cancellationToken: TestContext.Current.CancellationToken);
        Assert.True(!string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 1);
    }

    [Fact]
    public async Task TestReadAtomFeedGitHub()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("https://github.com/codehollow/AzureBillingRateCardSample/commits/master.atom", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal(FeedType.Atom, feed.Type);
        Assert.False(string.IsNullOrEmpty(feed.Title));
        Assert.NotEmpty(feed.Items);
    }

    [Fact]
    public async Task TestReadRss20GermanFeedPowershell()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("http://www.powershell.co.at/feed/", cancellationToken: TestContext.Current.CancellationToken);
        Assert.True(!string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadRss20FeedCharter97Handle403Forbidden()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("charter97.org/rss.php", cancellationToken: TestContext.Current.CancellationToken);
        Assert.True(!string.IsNullOrEmpty(feed.Title));
    }

    [Fact]
    public async Task TestReadRssScottHanselmanWeb()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("http://feeds.hanselman.com/ScottHanselman", cancellationToken: TestContext.Current.CancellationToken);
        Assert.True(!string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 0);
    }

    // 2026-11-14: Removed TestReadBuildAzure. https://buildazure.com redirects to the build5nines.com HTML home page,
    //   so the test only checked that some HTML downloaded.

    [Fact]
    public async Task TestReadNoticiasCatolicas()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("feeds.feedburner.com/NoticiasCatolicasAleteia", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("Noticias Catolicas", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTimeDoctor()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("https://www.timedoctor.com/blog/feed/", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("Time Doctor Blog", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadMikeC()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("https://mikeclayton.wordpress.com/feed/", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("Shift Happens!", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTheLPM()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("https://thelazyprojectmanager.wordpress.com/feed/", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("The Lazy Project Manager's Blog", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTechRep()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("https://www.techrepublic.com/rssfeeds/topic/project-management/", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("Project Management Articles & Tutorials | TechRepublic", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    // 2026-11-14: Removed TestReadAPOD. https://apod.nasa.gov/apod.rss now redirects to the
    //   https://science.nasa.gov/apod/ HTML page.

    [Fact]
    public async Task TestReadThaqafnafsak()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("http://www.thaqafnafsak.com/feed", cancellationToken: TestContext.Current.CancellationToken);
        Assert.False(string.IsNullOrEmpty(feed.Title));
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
        var feed = await _feedReaderSvc.ReadFromUrlAsync("http://feeds.feedburner.com/LiveBoldAndBloom", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("Live Bold and Bloom", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestSwedish_ISO8859_1()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("https://www.retriever-info.com/feed/2004645/intranet30/index.xml", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("intranet30", feed.Title);
    }

    [Fact]
    public async Task TestStadtfeuerwehrWeiz_ISO8859_1()
    {
        var feed = await _feedReaderSvc.ReadFromUrlAsync("http://www.stadtfeuerwehr-weiz.at/rss/einsaetze.xml", cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("Stadtfeuerwehr Weiz - Einsätze", feed.Title);
    }
    #endregion

    #region private helpers

    private async Task DownloadTestAsync(string url, CancellationToken cancellationToken = default)
    {
        var content = await _httpClientSvc.DownloadStringAsync(url, cancellationToken: cancellationToken);
        Assert.True(content.Length > 200);
    }

    #endregion
}
