using System.Buffers;
using System.Collections.Frozen;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Sagara.FeedReader.Extensions;
using Sagara.FeedReader.Parser;

namespace Sagara.FeedReader;

/// <summary>
/// Parses RSS 0.91, 0.92, 1.0, 2.0, Media RSS, and Atom feeds from content you already have, e.g., a file or a string.
/// </summary>
/// <remarks>
/// <para>To download and parse a feed from a URL, use <see cref="FeedReader"/> instead.</para>
/// <para><see cref="ParseAsync(Stream, CancellationToken)"/> and <see cref="Parse(string)"/> throw
/// <see cref="FeedParseException"/> when the content can't be parsed. <see cref="TryParseAsync(Stream, CancellationToken)"/>
/// and <see cref="TryParse(string)"/> return a failed <see cref="FeedReaderResult{T}"/> instead.</para>
/// </remarks>
/// <example>
/// <code>
/// await using var stream = File.OpenRead("feed.xml");
/// var feed = await FeedParser.ParseAsync(stream);
/// </code>
/// </example>
public static class FeedParser
{
    /// <summary>
    /// Parse a feed from a stream. The encoding declared in the document's XML declaration is honored;
    /// if there is none, or it's invalid, UTF-8 is used.
    /// </summary>
    /// <remarks>
    /// Reading starts at the stream's current position. Non-seekable streams (e.g., network streams) are
    /// buffered into memory first, because the content may need to be re-read with its declared encoding.
    /// The stream is not disposed.
    /// </remarks>
    /// <param name="feedContentStream">The feed document as a Stream.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>The parsed feed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="feedContentStream"/> is null.</exception>
    /// <exception cref="FeedParseException">The content can't be parsed. <see cref="FeedParseException.Kind"/> says why.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was cancelled.</exception>
    public static async Task<Feed> ParseAsync(Stream feedContentStream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(feedContentStream);

        try
        {
            if (feedContentStream.CanSeek)
            {
                return await ParseSeekableStreamAsync(feedContentStream, cancellationToken).ConfigureAwait(false);
            }

            using var bufferedStream = new MemoryStream();
            await feedContentStream.CopyToAsync(bufferedStream, cancellationToken).ConfigureAwait(false);
            bufferedStream.Position = 0L;

            return await ParseSeekableStreamAsync(bufferedStream, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex) when (ShouldWrap(ex))
        {
            throw Wrap(ex);
        }
    }

    /// <summary>
    /// Parse a feed from a string. The XML declaration's encoding is ignored, because the content has already
    /// been decoded into a string.
    /// </summary>
    /// <param name="feedContent">The feed document's content as a string.</param>
    /// <returns>The parsed feed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="feedContent"/> is null.</exception>
    /// <exception cref="FeedParseException">The content can't be parsed. <see cref="FeedParseException.Kind"/> says why.</exception>
    public static Feed Parse(string feedContent)
    {
        ArgumentNullException.ThrowIfNull(feedContent);

        try
        {
            feedContent = RemoveInvalidChars(feedContent);
            ThrowIfEmptyOrHtml(feedContent);

            return ParseFeedContent(feedContent);
        }
        catch (Exception ex) when (ShouldWrap(ex))
        {
            throw Wrap(ex);
        }
    }

    /// <summary>
    /// Parse a feed from a stream without throwing when the content can't be parsed. Otherwise the same as
    /// <see cref="ParseAsync(Stream, CancellationToken)"/>.
    /// </summary>
    /// <param name="feedContentStream">The feed document as a Stream.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A successful result with the parsed feed, or a failed result whose <see cref="FeedReaderResult{T}.Error"/>
    /// says why the content couldn't be parsed. <see cref="FeedReaderResult{T}.StatusCode"/> and
    /// <see cref="FeedReaderResult{T}.FinalUri"/> are always null.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="feedContentStream"/> is null.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was cancelled.</exception>
    public static async Task<FeedReaderResult<Feed>> TryParseAsync(Stream feedContentStream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(feedContentStream);

        try
        {
            var feed = await ParseAsync(feedContentStream, cancellationToken).ConfigureAwait(false);

            return FeedReaderResult.Success(feed);
        }
        catch (FeedParseException ex)
        {
            return ToFailure(ex);
        }
    }

    /// <summary>
    /// Parse a feed from a string without throwing when the content can't be parsed. Otherwise the same as
    /// <see cref="Parse(string)"/>.
    /// </summary>
    /// <param name="feedContent">The feed document's content as a string.</param>
    /// <returns>A successful result with the parsed feed, or a failed result whose <see cref="FeedReaderResult{T}.Error"/>
    /// says why the content couldn't be parsed. <see cref="FeedReaderResult{T}.StatusCode"/> and
    /// <see cref="FeedReaderResult{T}.FinalUri"/> are always null.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="feedContent"/> is null.</exception>
    public static FeedReaderResult<Feed> TryParse(string feedContent)
    {
        ArgumentNullException.ThrowIfNull(feedContent);

        try
        {
            return FeedReaderResult.Success(Parse(feedContent));
        }
        catch (FeedParseException ex)
        {
            return ToFailure(ex);
        }
    }


    //
    // Private methods
    //

    private static FeedReaderResult<Feed> ToFailure(FeedParseException ex)
        => FeedReaderResult.Failure<Feed>(new FeedReaderError(ex.Kind, ex.Message, ex));

    /// <summary>
    /// Everything except our own exception and cancellation gets wrapped in a <see cref="FeedParseException"/>,
    /// so that callers only have one exception type to handle.
    /// </summary>
    private static bool ShouldWrap(Exception ex)
        => ex is not FeedParseException and not OperationCanceledException;

    private static FeedParseException Wrap(Exception ex)
        => ex is XmlException xmlEx
            ? CreateInvalidXmlException(xmlEx)
            : new FeedParseException(FeedReaderErrorKind.ParseError, $"The feed could not be parsed: {ex.Message}", ex);

    /// <summary>
    /// Read the stream from its current position, re-reading it with the declared encoding if that isn't UTF-8,
    /// and then parse it.
    /// </summary>
    private static async Task<Feed> ParseSeekableStreamAsync(Stream feedContentStream, CancellationToken cancellationToken)
    {
        var startPosition = feedContentStream.Position;

        // Read with the default encoding (UTF-8) so that we can read the document's declared encoding.
        var feedContent = await ReadToEndAsync(feedContentStream, Encoding.UTF8, cancellationToken).ConfigureAwait(false);
        ThrowIfEmptyOrHtml(feedContent);

        var encodingAttrValue = GetEncodingAttributeValueFromXmlDeclaration(feedContent);
        var encoding = GetEncodingFromAttributeValue(encodingAttrValue);

        if (encoding != Encoding.UTF8)
        {
            // Re-read the stream with the declared encoding.
            // In some cases - ISO-8859-1 - Encoding.UTF8.GetString doesn't work correctly, so converting
            //   from UTF8 to ISO-8859-1 doesn't work and the result is wrong.
            //   See: FullParseTest.TestRss20ParseSwedishFeedWithIso8859_1
            feedContentStream.Position = startPosition;
            feedContent = await ReadToEndAsync(feedContentStream, encoding, cancellationToken).ConfigureAwait(false);
        }

        return ParseFeedContent(feedContent);
    }

    /// <summary>
    /// Read the rest of the stream with the given encoding, and remove invalid characters.
    /// </summary>
    private static async Task<string> ReadToEndAsync(Stream stream, Encoding encoding, CancellationToken cancellationToken)
    {
        using var streamReader = new StreamReader(stream, encoding, leaveOpen: true);

        var content = await streamReader.ReadToEndAsync(cancellationToken).ConfigureAwait(false);

        return RemoveInvalidChars(content);
    }

    /// <summary>
    /// Parse cleaned-up feed content into a <see cref="Feed"/>.
    /// </summary>
    private static Feed ParseFeedContent(string feedContent)
    {
        var feedDoc = XDocument.Parse(feedContent);

        var feedType = ParseFeedType(feedDoc);
        var parser = Factory.GetParser(feedType);
        var baseFeed = parser.Parse(feedContent, feedDoc);

        return baseFeed.ToFeed();
    }

    /// <summary>
    /// Fail fast with a specific error when the content is empty, or is obviously an HTML page. Many HTML pages
    /// are not well-formed XML, so without this check they would be reported as invalid XML.
    /// </summary>
    /// <param name="feedContent">The feed content with invalid characters and leading white space removed.</param>
    private static void ThrowIfEmptyOrHtml(string feedContent)
    {
        if (feedContent.Length == 0)
        {
            throw new FeedParseException(FeedReaderErrorKind.InvalidXml, "The feed content is empty.");
        }

        var firstMarkup = SkipXmlDeclarationAndComments(feedContent.AsSpan());

        if (firstMarkup.StartsWith("<!doctype html", StringComparison.OrdinalIgnoreCase)
            || firstMarkup.StartsWith("<html", StringComparison.OrdinalIgnoreCase))
        {
            throw CreateNotAFeedException();
        }
    }

    /// <summary>
    /// Skip past a leading XML declaration and any comments, so that we can see the first real markup.
    /// </summary>
    private static ReadOnlySpan<char> SkipXmlDeclarationAndComments(ReadOnlySpan<char> content)
    {
        content = content.TrimStart();

        if (content.StartsWith("<?xml", StringComparison.OrdinalIgnoreCase))
        {
            var endOfDeclaration = content.IndexOf("?>", StringComparison.Ordinal);
            content = endOfDeclaration < 0
                ? []
                : content[(endOfDeclaration + 2)..].TrimStart();
        }

        while (content.StartsWith("<!--", StringComparison.Ordinal))
        {
            var endOfComment = content.IndexOf("-->", StringComparison.Ordinal);
            content = endOfComment < 0
                ? []
                : content[(endOfComment + 3)..].TrimStart();
        }

        return content;
    }

    private static FeedParseException CreateInvalidXmlException(XmlException ex)
        => new(FeedReaderErrorKind.InvalidXml, $"The feed content is not well-formed XML: {ex.Message}", ex);

    private static FeedParseException CreateNotAFeedException()
        => new(FeedReaderErrorKind.NotAFeed, "The content is an HTML page, not a feed. If it came from a web page URL, use GetFeedUrlsFromPageAsync to find the page's feeds.");

    /// <summary>
    /// Try to read the encoding from the XML declaration.
    /// </summary>
    /// <remarks>
    /// See: https://stackoverflow.com/a/34294515
    /// </remarks>
    /// <param name="feedContent">The feed content with invalid characters removed.</param>
    private static string? GetEncodingAttributeValueFromXmlDeclaration(string feedContent)
    {
        using var stringReader = new StringReader(feedContent);

        // This allows us to read the declaration if it's present, regardless of whether or not there
        //   is a fully formed root element.
        XmlReaderSettings xmlReaderSettings = new() { ConformanceLevel = ConformanceLevel.Fragment };

        using var xmlReader = XmlReader.Create(stringReader, xmlReaderSettings);

        // Try to consume the XML declaration.
        if (!xmlReader.Read())
        {
            throw new FeedParseException(FeedReaderErrorKind.InvalidXml, "The feed content does not contain any XML.");
        }

        // Get the encoding attribute's value.
        return xmlReader.GetAttribute("encoding");
    }

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
            // Version is a required attribute, but some feeds omit it. Treat those as generic RSS.
            string? version = doc.Root.Attribute("version")?.Value;

            if (version is null)
            {
                return FeedType.Rss;
            }

            if (version.EqualsIgnoreCase("2.0"))
            {
                if (doc.GetRootNamespaceDeclarationAttribute("media") is not null)
                {
                    // Media RSS.
                    return FeedType.MediaRss;
                }

                // Handle it as a regular RSS 2.0 document.
                return FeedType.Rss_2_0;
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

        if (rootElementName.EqualsIgnoreCase("html"))
        {
            throw CreateNotAFeedException();
        }

        throw new FeedParseException(FeedReaderErrorKind.UnsupportedFeedType, $"Unsupported feed type. The root element is <{rootElementName}>; expected <rss>, <rdf:RDF>, or <feed>.");
    }

    /// <summary>
    /// Try to get the <see cref="Encoding"/> from the feed content's XML declaration encoding attribute.
    /// If none found, or if it's invalid, return UTF-8.
    /// </summary>
    /// <param name="encodingAttrValue">The encoding attribute value as read from the feed content's XML declaration.</param>
    /// <returns>The <see cref="Encoding"/> specified by the document, or UTF-8 if none specified or it's invalid.</returns>
    private static Encoding GetEncodingFromAttributeValue(string? encodingAttrValue)
    {
        if (string.IsNullOrWhiteSpace(encodingAttrValue))
        {
            // The encoding attribute was missing, or it had no value. Assume UTF-8.
            return Encoding.UTF8;
        }

        // Justification: we catch an error due to an invalid encoding, and then return the default of UTF8.
#pragma warning disable CA1031 // Do not catch general exception types
        try
        {
            return Encoding.GetEncoding(name: encodingAttrValue);
        }
        catch (Exception)
        {
            // The document encoding is invalid. Swallow the error and return the default encoding of UTF-8.
            return Encoding.UTF8;
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
        if (feedContent.Length < 256)
        {
            return RemoveInvalidCharsSpanHelper(feedContent, stackalloc char[feedContent.Length]);
        }

        var pooledBuffer = ArrayPool<char>.Shared.Rent(minimumLength: feedContent.Length);
        try
        {
            return RemoveInvalidCharsSpanHelper(feedContent, pooledBuffer.AsSpan());
        }
        finally
        {
            ArrayPool<char>.Shared.Return(pooledBuffer);
        }
    }


    private static string RemoveInvalidCharsSpanHelper(string feedContent, Span<char> destBuffer)
    {
        var destBufferPos = 0;
        var charsWritten = 0; // Turns out to be the same as destBufferPos, but use a separate variable for clarity.

        foreach (var ch in feedContent.AsSpan())
        {
            if (InvalidCharactersToRemove.Value.Contains(ch))
            {
                continue;
            }

            destBuffer[destBufferPos++] = ch;
            charsWritten++;
        }

        // XDocument chokes with leading white space, so ensure there isn't any.
        return feedContent.Length == charsWritten
            ? feedContent.TrimStart()
            : destBuffer.Slice(start: 0, length: charsWritten).TrimStart().ToString();
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
