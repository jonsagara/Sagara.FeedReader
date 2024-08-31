using Sagara.FeedReader.Modules.WordPressExport;
using Sagara.FeedReader.Tests.Unit.Fixtures;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

[Collection(nameof(ServiceScopeCollection))]
public class WordPressExportTest
{
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
    public async Task TestWordPressExportFeed_Async()
    {
        var feed = await FeedReader.ReadFromFileAsync("Feeds/Rss20WordPressExport.xml");

        var wpExportChannel = feed.GetWordPressExportChannel();

        Assert.Equal("1.2", wpExportChannel.WxrVersion);
        Assert.Equal("http://wordpress.com/", wpExportChannel.BaseSiteUrl);
        Assert.Equal("http://randomauthorpersonexample.com", wpExportChannel.BaseBlogUrl);

        Assert.NotNull(wpExportChannel.Author);
        Assert.Equal(123456789, wpExportChannel.Author.Id);
        Assert.Equal("randomauthorperson", wpExportChannel.Author.Login);
        Assert.Equal("randomauthorperson@example.com", wpExportChannel.Author.Email);
        Assert.Equal("Random Author Person", wpExportChannel.Author.DisplayName);
        Assert.Equal("Random", wpExportChannel.Author.FirstName);
        Assert.Equal("Person", wpExportChannel.Author.LastName);

        var wpCategories = wpExportChannel.Categories.ToArray();
        Assert.Equal(2, wpCategories.Length);

        Assert.Equal(123L, wpCategories[0].TermId);
        Assert.Equal("blog", wpCategories[0].NiceName);
        Assert.Equal("Blog", wpCategories[0].Name);

        Assert.Equal(124L, wpCategories[1].TermId);
        Assert.Equal("uncategorized", wpCategories[1].NiceName);
        Assert.Equal("Uncategorized", wpCategories[1].Name);

        var wpTags = wpExportChannel.Tags.ToArray();
        Assert.Equal(2, wpTags.Length);

        Assert.Equal(400L, wpTags[0].TermId);
        Assert.Equal("alaska", wpTags[0].Slug);
        Assert.Equal("alaska", wpTags[0].Name);

        Assert.Equal(401L, wpTags[1].TermId);
        Assert.Equal("fishing-trip", wpTags[1].Slug);
        Assert.Equal("fishing-trip", wpTags[1].Name);


        Assert.Equal(2, feed.Items.Count);

        //
        // Item 1
        //

        var item1 = feed.Items.ElementAt(0).GetWordPressExportItem();

        Assert.NotNull(item1);
        Assert.Equal("This is an about page.", item1.Content);
        Assert.Equal("", item1.Excerpt);
        Assert.Equal(2, item1.PostId);
        Assert.Equal(Helpers.TryParseDateTime("2007-12-29 18:31:29"), item1.PostDate);
        Assert.Equal("2007-12-29 18:31:29".ParseUtcOrDefault(), item1.PostDateGmt);
        Assert.Equal(Helpers.TryParseDateTime("2020-12-07 09:03:41"), item1.PostModified);
        Assert.Equal("2020-12-07 17:03:41".ParseUtcOrDefault(), item1.PostModifiedGmt);
        Assert.Equal("open", item1.CommentStatus);
        Assert.Equal("open", item1.PingStatus);
        Assert.Equal("about", item1.PostName);
        Assert.Equal("publish", item1.Status);
        Assert.Equal(0L, item1.PostParent);
        Assert.Equal(0L, item1.MenuOrder);
        Assert.Equal("page", item1.PostType);
        Assert.Equal("", item1.PostPassword);
        Assert.False(item1.IsSticky);

        Assert.Single(item1.Comments);
        var item1Comments = item1.Comments.ToArray();
        Assert.Equal(500, item1Comments[0].Id);
        Assert.Equal("Random Commenter", item1Comments[0].Author);
        Assert.Equal("randomcommenter@example.com", item1Comments[0].AuthorEmail);
        Assert.Equal("", item1Comments[0].AuthorUrl);
        Assert.Equal("512.512.512.512", item1Comments[0].AuthorIP);
        Assert.Equal(Helpers.TryParseDateTime("2022-10-25 10:02:27"), item1Comments[0].Date);
        Assert.Equal("2022-10-25 17:02:27".ParseUtcOrDefault(), item1Comments[0].DateGmt);
        var item1CommentText = """
This is a random comment.

Thanks for reading.
""";
        Assert.Equal(item1CommentText.Replace("\r\n", "\n"), item1Comments[0].Content);


        //
        // Item 2
        //

        var item2 = feed.Items.ElementAt(1).GetWordPressExportItem();

        Assert.NotNull(item2);

        var item2Content = """
<p>This is text.</p>
<p>This is more text.</p>

""";
        Assert.Equal(item2Content.Replace("\r\n", "\n"), item2.Content);
        Assert.Equal("", item2.Excerpt);
        Assert.Equal(3, item2.PostId);
        Assert.Equal(Helpers.TryParseDateTime("2006-01-23 00:44:00"), item2.PostDate);
        Assert.Equal("2006-01-23 05:44:00".ParseUtcOrDefault(), item2.PostDateGmt);
        Assert.Equal(Helpers.TryParseDateTime("2006-01-23 00:44:00"), item2.PostModified);
        Assert.Equal("2006-01-23 05:44:00".ParseUtcOrDefault(), item2.PostModifiedGmt);
        Assert.Equal("closed", item2.CommentStatus);
        Assert.Equal("closed", item2.PingStatus);
        Assert.Equal("this-is-a-title", item2.PostName);
        Assert.Equal("publish", item2.Status);
        Assert.Equal(0L, item2.PostParent);
        Assert.Equal(0L, item2.MenuOrder);
        Assert.Equal("post", item2.PostType);
        Assert.Equal("", item2.PostPassword);
        Assert.False(item2.IsSticky);

        Assert.Empty(item2.Comments);
    }
}
