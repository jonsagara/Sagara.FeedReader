using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class InvalidChars
{
    /// <summary>
    /// Removes some characters at the beginning of the document. These shouldn't be there, but 
    /// unfortunately they are sometimes there. If they are not removed, xml parsing would fail.
    /// </summary>
    /// <param name="feedContent">RSS feed content.</param>
    /// <returns>Cleaned up RSS feed content.</returns>
    [Benchmark(Baseline = true)]
    public string RemoveInvalidCharsWithReplace()
    {
        var feedContent = File.ReadAllText("Feeds/Rss20MicrosoftBotFramework.xml");

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

        // We explicitly leave some white space (CR/LF/TAB) alone above, so don't remove it now.
        //   Calling trim allocates a whole new string.
        return feedContent;
    }

    //
    // string.Replace(...) is HEAVILY optimized. The following StringBuilder-based method is several
    //   times slower and allocates an order of magnitude more memory.
    //

    [Benchmark]
    public string RemoveInvalidCharsWithSingleCharInspection()
    {
        var feedContent = File.ReadAllText("Feeds/Rss20MicrosoftBotFramework.xml");
        var output = new StringBuilder(feedContent.Length);

        for (var ixChar = 0; ixChar < feedContent.Length; ixChar++)
        {
            var currChar = feedContent.AsSpan()[ixChar];

            if (char.IsControl(currChar) && currChar != 0x0D && currChar != 0x0A && currChar != 0x09)
            {
                // Omit control characters except CR, LF, and TAB.
                continue;
            }

            output.Append(currChar);
        }

        return output.ToString();
    }
}
