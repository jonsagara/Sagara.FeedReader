namespace Sagara.FeedReader.Parser;

using System.Collections.Frozen;
using System.Text;
using System.Xml.Linq;
using Sagara.FeedReader.Extensions;

/// <summary>
/// Internal FeedParser - returns the type of the feed or the parsed feed.
/// </summary>
internal static class FeedParser
{
    /// <summary>
    /// Returns the parsed feed. This method tries to use the encoding of the received file.
    /// If none found, or it's invalid, it uses UTF8.
    /// </summary>
    /// <param name="feedContentStream">The feed document as a Stream.</param>
    /// <param name="cancellationToken">token to cancel operation</param>
    /// <returns>Parsed feed</returns>
    public static async Task<Feed> GetFeedFromStreamAsync(Stream feedContentStream, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(feedContentStream);

        string? feedContent = null;
        XDocument? feedDoc = null;
        Encoding encoding = Encoding.UTF8;

        // Try to load the document with the default encoding so that we can read its declared encoding.
        feedContentStream.Position = 0L;

        using (var streamReader = new StreamReader(feedContentStream, encoding, leaveOpen: true))
        {
            // Read it into a string so that we can remove invalid characters.
            feedContent = await streamReader.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
            feedContent = RemoveInvalidChars(feedContent);

            // Parse it so that we can try to get the declared encoding, if any.
            feedDoc = XDocument.Parse(feedContent);
            encoding = GetEncoding(feedDoc);
        }

        if (encoding != Encoding.UTF8)
        {
            // Re-read the stream with the declared encoding.
            // In some cases - ISO-8859-1 - Encoding.UTF8.GetString doesn't work correctly, so converting
            //   from UTF8 to ISO-8859-1 doesn't work and the result is wrong.
            //   See: FullParseTest.TestRss20ParseSwedishFeedWithIso8859_1

            feedContentStream.Position = 0L;

            using (var streamReader = new StreamReader(feedContentStream, encoding, leaveOpen: true))
            {
                feedContent = await streamReader.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
                feedContent = RemoveInvalidChars(feedContent);
            }
        }

        // Get the feed type from the original parsed document.
        var feedType = ParseFeedType(feedDoc);

        // Get the correct parser based on the feed type.
        var parser = Factory.GetParser(feedType);

        // If the declared encoding is UTF-8, then we didn't read feedConentData again with a
        //   different encoding, and there's no need to have the parser reparse the XDocument.
        var feed = encoding == Encoding.UTF8
            ? parser.Parse(feedContent, feedDoc)
            : parser.Parse(feedContent);

        return feed.ToFeed();
    }

    /// <summary>
    /// Returns the parsed feed. This method does NOT check the encoding of the received file.
    /// </summary>
    /// <param name="feedContent">The feed document's content as a string.</param>
    /// <returns>Parsed feed</returns>
    public static Feed GetFeedFromString(string feedContent)
    {
        ArgumentNullException.ThrowIfNull(feedContent);

        feedContent = RemoveInvalidChars(feedContent);

        XDocument feedDoc = XDocument.Parse(feedContent);

        var feedType = ParseFeedType(feedDoc);
        var parser = Factory.GetParser(feedType);
        var feed = parser.Parse(feedContent, feedDoc);

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
    /// Tries to read the encoding from the document's XML declaration. If none found, or if it's invalid,
    /// returns UTF8.
    /// </summary>
    /// <param name="feedDoc">rss feed document</param>
    /// <returns>encoding or utf8 by default</returns>
    private static Encoding GetEncoding(XDocument feedDoc)
    {
        Encoding encoding = Encoding.UTF8;

        // Justification: we catch an error due to an invalid encoding, and then return the default of UTF8.
#pragma warning disable CA1031 // Do not catch general exception types
        try
        {
            var encodingStr = feedDoc.Document!.Declaration?.Encoding;
            if (!string.IsNullOrEmpty(encodingStr))
            {
                encoding = Encoding.GetEncoding(encodingStr);
            }

            return encoding;
        }
        catch
        {
            // The document encoding is invalid. Swallow the error and return the default encoding.
            return encoding;
        }
#pragma warning restore CA1031 // Do not catch general exception types
    }

    /// <summary>
    /// Removes some characters at the beginning of the document. These shouldn't be there, but 
    /// unfortunately they are sometimes there. If they are not removed, xml parsing would fail.
    /// </summary>
    /// <param name="feedContent">RSS feed content.</param>
    /// <returns>Cleaned up RSS feed content.</returns>
    internal static string RemoveInvalidChars(string feedContent)
    {
        // Replaces all control characters except CR LF (\r\n) and TAB.
        for (int charCode = 0; charCode <= 31; charCode++)
        {
            if (charCode == 0x0D || charCode == 0x0A || charCode == 0x09)
            {
                continue;
            }

            feedContent = feedContent.Replace(((char)charCode).ToString(), string.Empty, StringComparison.Ordinal);
        }

        // Replace DEL.
        feedContent = feedContent.Replace(((char)127).ToString(), string.Empty, StringComparison.Ordinal);

        // Replaces special char, fixes issues with at least one feed.
        feedContent = feedContent.Replace(((char)65279).ToString(), string.Empty, StringComparison.Ordinal);

        // XDocument chokes with leading white space, so ensure there isn't any.
        return feedContent.TrimStart();
    }


    /// <summary>
    /// Certain control characters that cause XML parsing to fail. They shouldn't be there, but sometimes are.
    /// </summary>
    internal static readonly Lazy<FrozenSet<char>> InvalidCharactersToRemove = new(() =>
    {
        List<char> invalidChars = new();

        // ASCII [0, 31], excluding newline, carriage return, and tab.
        var mostAsciiControlChars = Enumerable
            .Range(start: 0, count: 32)
            .Select(i => (char)i)
            .Where(i => i != '\n' && i != '\r' && i != '\t');

        invalidChars.AddRange(mostAsciiControlChars);

        // DEL
        invalidChars.Add((char)127);

        // Special char that crashes at least one (unknown to me) feed.
        // Zero-width, no-break space: U+FEFF
        // See: https://stackoverflow.com/a/9691839
        invalidChars.Add((char)65279);

        return invalidChars.ToFrozenSet();
    });
}
