using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Sagara.FeedReader.Tests.Integration.Fixtures;
using Xunit;

namespace Sagara.FeedReader.Tests.Integration;

[Collection(nameof(ServiceScopeCollection))]
public class FeedReaderTest
{
    private readonly IFeedReader _feedReader;

    public FeedReaderTest(HostFixture hostFixture)
    {
        _feedReader = hostFixture.ServiceScope.ServiceProvider.GetRequiredService<IFeedReader>();
    }


    #region special cases

    // 2026-11-14: Removed TestDownload400BadRequest. http://www.methode.at/blog?format=RSS now returns 404,
    //   and the test only passed because DownloadTestAsync doesn't check the status code.

    [Fact]
    public async Task TestAcceptHeaderForbiddenWithParsing()
    {
        // results in 403 Forbidden if webclient does not have the accept header set
        var feed = await GetFeedOrFailAsync("http://www.girlsguidetopm.com/feed/");
        Assert.True(feed.Items.Count > 2);
        Assert.False(string.IsNullOrEmpty(feed.Title));
    }

    // 2026-11-14: Removed TestAcceptForbiddenUserAgent. It downloaded https://mikeclayton.wordpress.com/feed/,
    //   which TestReadMikeC already reads and parses.

    [Fact]
    public async Task TestAcceptForbiddenUserAgentWrike()
    {
        // results in 403 Forbidden if webclient does not have the user agent set
        var result = await _feedReader.GetFeedUrlsFromPageAsync("https://www.wrike.com/blog", cancellationToken: TestContext.Current.CancellationToken);

        AssertSuccess(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    #endregion

    #region Error results

    [Fact]
    public async Task TestHtmlPageReturnsNotAFeed()
    {
        var result = await _feedReader.GetFeedAsync("https://example.com/", cancellationToken: TestContext.Current.CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.NotAFeed, result.Error.Kind);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task TestMissingFeedReturnsHttpError404()
    {
        var result = await _feedReader.GetFeedAsync("https://github.com/codehollow/does-not-exist-xyz/commits/master.atom", cancellationToken: TestContext.Current.CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal(FeedReaderErrorKind.HttpError, result.Error.Kind);
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
    }

    #endregion

    #region ParseRssLinksFromHTML

    [Fact]
    public async Task TestParseRssLinksCodehollow()
    {
        await TestParseRssLinksAsync("https://codehollow.com", 2);
    }

    // 2026-11-14: Removed TestParseRssLinksNYTimes. nytimes.com intermittently returns a 403 bot-block page,
    //   which (without a status code check) shows up as zero links.

    [Fact]
    public async Task TestParseRssLinksTechMeme()
    {
        await TestParseRssLinksAsync("https://techmeme.com/", 2);
    }

    // 2026-11-14: Removed TestParseRssLinksTechMemeNakedDomain. URLs without a scheme now throw ArgumentException,
    //   which is covered by unit tests.

    [Fact]
    public async Task TestParseRssLinksTechMemeWwwDomain()
    {
        await TestParseRssLinksAsync("https://www.techmeme.com/", 2);
    }

    private async Task TestParseRssLinksAsync(string url, int expectedNumberOfLinks)
    {
        var result = await _feedReader.GetFeedUrlsFromPageAsync(url, cancellationToken: TestContext.Current.CancellationToken);

        var links = AssertSuccess(result);
        Assert.Equal(expectedNumberOfLinks, links.Count);
        Assert.All(links, link => Assert.True(Uri.IsWellFormedUriString(link.Url, UriKind.Absolute), link.Url));
    }

    #endregion

    // 2026-11-14: Removed TestParseAndAbsoluteUrlDerStandard1. derstandard.at no longer has any feed <link> tags,
    //   so the loop never ran and the test passed vacuously. Absolute URL resolution is covered by unit tests.

    #region Read Feed

    // 2026-11-14: Removed TestReadAdobeFeed. https://blog.adobe.com/feed.xml now returns a 404 HTML page.
    //   Atom parsing of the Adobe feed is still covered by the AtomAdobe.xml unit test fixture.

    [Fact]
    public async Task TestReadSimpleFeed()
    {
        var feed = await GetFeedOrFailAsync("https://arminreiter.com/feed");
        Assert.Equal("arminreiter.com", feed.Title);
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
        var feed = await GetFeedOrFailAsync("http://rss.orf.at/news.xml");
        Assert.Equal("news.ORF.at", feed.Title);
        Assert.True(feed.Items.Count > 10);
    }

    [Fact]
    public async Task TestReadAtomFeedHeise()
    {
        var feed = await GetFeedOrFailAsync("https://www.heise.de/newsticker/heise-atom.xml");
        Assert.False(string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 1);
    }

    [Fact]
    public async Task TestReadAtomFeedGitHub()
    {
        var feed = await GetFeedOrFailAsync("https://github.com/codehollow/AzureBillingRateCardSample/commits/master.atom");
        Assert.Equal(FeedType.Atom, feed.Type);
        Assert.False(string.IsNullOrEmpty(feed.Title));
        Assert.NotEmpty(feed.Items);
    }

    [Fact]
    public async Task TestReadRss20GermanFeedPowershell()
    {
        var feed = await GetFeedOrFailAsync("http://www.powershell.co.at/feed/");
        Assert.False(string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadRss20FeedCharter97Handle403Forbidden()
    {
        var feed = await GetFeedOrFailAsync("https://charter97.org/rss.php");
        Assert.False(string.IsNullOrEmpty(feed.Title));
    }

    [Fact]
    public async Task TestReadRssScottHanselmanWeb()
    {
        var feed = await GetFeedOrFailAsync("http://feeds.hanselman.com/ScottHanselman");
        Assert.False(string.IsNullOrEmpty(feed.Title));
        Assert.True(feed.Items.Count > 0);
    }

    // 2026-11-14: Removed TestReadBuildAzure. https://buildazure.com redirects to the build5nines.com HTML home page,
    //   so the test only checked that some HTML downloaded.

    [Fact]
    public async Task TestReadNoticiasCatolicas()
    {
        var feed = await GetFeedOrFailAsync("https://feeds.feedburner.com/NoticiasCatolicasAleteia");
        Assert.Equal("Noticias Catolicas", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTimeDoctor()
    {
        var feed = await GetFeedOrFailAsync("https://www.timedoctor.com/blog/feed/");
        Assert.Equal("Time Doctor Blog", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadMikeC()
    {
        // results in 403 Forbidden if webclient does not have the accept header or user agent set
        var feed = await GetFeedOrFailAsync("https://mikeclayton.wordpress.com/feed/");
        Assert.Equal("Shift Happens!", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTheLPM()
    {
        var feed = await GetFeedOrFailAsync("https://thelazyprojectmanager.wordpress.com/feed/");
        Assert.Equal("The Lazy Project Manager's Blog", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestReadTechRep()
    {
        var feed = await GetFeedOrFailAsync("https://www.techrepublic.com/rssfeeds/topic/project-management/");
        Assert.Equal("Project Management Articles & Tutorials | TechRepublic", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    // 2026-11-14: Removed TestReadAPOD. https://apod.nasa.gov/apod.rss now redirects to the
    //   https://science.nasa.gov/apod/ HTML page.

    [Fact]
    public async Task TestReadThaqafnafsak()
    {
        var feed = await GetFeedOrFailAsync("http://www.thaqafnafsak.com/feed");
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
        var feed = await GetFeedOrFailAsync("http://feeds.feedburner.com/LiveBoldAndBloom");
        Assert.Equal("Live Bold and Bloom", feed.Title);
        Assert.True(feed.Items.Count > 0);
    }

    [Fact]
    public async Task TestSwedish_ISO8859_1()
    {
        var feed = await GetFeedOrFailAsync("https://www.retriever-info.com/feed/2004645/intranet30/index.xml");
        Assert.Equal("intranet30", feed.Title);
    }

    [Fact]
    public async Task TestStadtfeuerwehrWeiz_ISO8859_1()
    {
        var feed = await GetFeedOrFailAsync("http://www.stadtfeuerwehr-weiz.at/rss/einsaetze.xml");
        Assert.Equal("Stadtfeuerwehr Weiz - Einsätze", feed.Title);
    }

    #endregion

    #region private helpers

    /// <summary>
    /// Get the feed, failing the test with the error kind and message if it couldn't be read.
    /// </summary>
    private async Task<Feed> GetFeedOrFailAsync(string url)
    {
        var result = await _feedReader.GetFeedAsync(url, cancellationToken: TestContext.Current.CancellationToken);

        return AssertSuccess(result);
    }

    /// <summary>
    /// Fail the test with the error kind and message if the result is a failure. Otherwise, return its value.
    /// </summary>
    private static T AssertSuccess<T>(FeedReaderResult<T> result)
        where T : class
    {
        Assert.True(result.IsSuccess, $"[{result.Error?.Kind}] {result.Error?.Message} (HTTP {(int?)result.StatusCode}, final URI {result.FinalUri})");

        return result.Value;
    }

    #endregion
}
