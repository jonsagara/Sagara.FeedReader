namespace CodeHollow.FeedReader.Parser;

using System.Text;
using System.Xml.Linq;
using CodeHollow.FeedReader.Extensions;

/// <summary>
/// Internal FeedParser - returns the type of the feed or the parsed feed.
/// </summary>
internal static class FeedParser
{
    /// <summary>
    /// Returns the parsed feed. This method checks the encoding of the received file.
    /// </summary>
    /// <param name="feedContentData">The feed document as a byte array.</param>
    /// <returns>Parsed feed</returns>
    public static Feed GetFeed(byte[] feedContentData)
    {
        // 1.) get string of the content
        string feedContent = Encoding.UTF8.GetString(feedContentData);
        feedContent = RemoveWrongChars(feedContent);

        // 2.) read document to get the used encoding
        XDocument feedDoc = XDocument.Parse(feedContent);

        // 3.) get used encoding
        Encoding encoding = GetEncoding(feedDoc);

        // 4.) if not UTF8 - reread the data.
        // In some cases - ISO-8859-1 - Encoding.UTF8.GetString doesn't work correctly, so converting
        //   from UTF8 to ISO-8859-1 doesn't work and the result is wrong.
        //   See: FullParseTest.TestRss20ParseSwedishFeedWithIso8859_1
        if (encoding != Encoding.UTF8)
        {
            feedContent = encoding.GetString(feedContentData);
            feedContent = RemoveWrongChars(feedContent);
        }

        var feedType = ParseFeedType(feedDoc);
        var parser = Factory.GetParser(feedType);
        var feed = parser.Parse(feedContent);

        return feed.ToFeed();
    }

    /// <summary>
    /// Returns the parsed feed. This method does NOT check the encoding of the received file.
    /// </summary>
    /// <param name="feedContent">The feed document's content as a string.</param>
    /// <returns>Parsed feed</returns>
    public static Feed GetFeed(string feedContent)
    {
        feedContent = RemoveWrongChars(feedContent);

        XDocument feedDoc = XDocument.Parse(feedContent);

        var feedType = ParseFeedType(feedDoc);
        var parser = Factory.GetParser(feedType);
        var feed = parser.Parse(feedContent);

        return feed.ToFeed();
    }


    //
    // Private methods
    //

    /// <summary>
    /// Returns the feed type - rss 1.0, rss 2.0, atom, ...
    /// </summary>
    /// <param name="doc">the xml document</param>
    /// <returns>the feed type</returns>
    private static FeedType ParseFeedType(XDocument doc)
    {
        string rootElementName = doc.Root!.Name.LocalName;

        if (rootElementName.EqualsIgnoreCase("feed"))
        {
            return FeedType.Atom;
        }

        if (rootElementName.EqualsIgnoreCase("rdf"))
        {
            return FeedType.Rss_1_0;
        }

        if (rootElementName.EqualsIgnoreCase("rss"))
        {
            // Version is a required attribute.
            string version = doc.Root.Attribute("version")!.Value;

            if (version.EqualsIgnoreCase("2.0"))
            {
                if (doc.Root.Attribute(XName.Get("media", XNamespace.Xmlns.NamespaceName)) is not null)
                {
                    return FeedType.MediaRss;
                }
                else
                {
                    return FeedType.Rss_2_0;
                }
            }

            if (version.EqualsIgnoreCase("0.91"))
            {
                return FeedType.Rss_0_91;
            }

            if (version.EqualsIgnoreCase("0.92"))
            {
                return FeedType.Rss_0_92;
            }

            return FeedType.Rss;
        }

        throw new FeedTypeNotSupportedException($"Unknown feed type {rootElementName}");
    }

    /// <summary>
    /// reads the encoding from a feed document, returns UTF8 by default
    /// </summary>
    /// <param name="feedDoc">rss feed document</param>
    /// <returns>encoding or utf8 by default</returns>
    private static Encoding GetEncoding(XDocument feedDoc)
    {
        Encoding encoding = Encoding.UTF8;

        try
        {
            var encodingStr = feedDoc.Document!.Declaration?.Encoding;
            if (!string.IsNullOrEmpty(encodingStr))
            {
                encoding = Encoding.GetEncoding(encodingStr);
            }
        }
        catch { } // ignore and return default encoding
        return encoding;
    }

    /// <summary>
    /// Removes some characters at the beginning of the document. These shouldn't be there, but 
    /// unfortunately they are sometimes there. If they are not removed, xml parsing would fail.
    /// </summary>
    /// <param name="feedContent">RSS feed content.</param>
    /// <returns>Cleaned up RSS feed content.</returns>
    private static string RemoveWrongChars(string feedContent)
    {
        // Replaces all control characters except CR LF (\r\n) and TAB.
        for (int charCode = 0; charCode <= 31; charCode++)
        {
            if (charCode == 0x0D || charCode == 0x0A || charCode == 0x09)
            {
                continue;
            }

            feedContent = feedContent.Replace(((char)charCode).ToString(), string.Empty);
        }

        // Replace DEL.
        feedContent = feedContent.Replace(((char)127).ToString(), string.Empty);

        // Replaces special char, fixes issues with at least one feed.
        feedContent = feedContent.Replace(((char)65279).ToString(), string.Empty);

        return feedContent.Trim();
    }
}
