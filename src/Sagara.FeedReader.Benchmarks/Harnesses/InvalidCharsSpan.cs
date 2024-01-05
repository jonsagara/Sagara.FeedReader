using System.Buffers;
using System.Collections.Frozen;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class InvalidCharsSpan
{
    private static FrozenSet<char> GenerateInvalidCharsSet()
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
    }

    /// <summary>
    /// Certain control characters that cause XML parsing to fail. They shouldn't be there, but sometimes are.
    /// </summary>
    internal static readonly Lazy<FrozenSet<char>> InvalidCharactersToRemove = new(GenerateInvalidCharsSet);

    //private static readonly FrozenSet<char> _invalidCharsToRemove = GenerateInvalidCharsSet();

    private static readonly HashSet<string> _invalidCharStrings = Enumerable.Range(start: 0, count: 32)
        .Concat(new[] { 127, 65279 })
        .Where(ixChar => ixChar != 0x0D && ixChar != 0x0A && ixChar != 0x09)
        .Select(ix => ((char)ix).ToString())
        .ToHashSet();

    private string _feedContent = null!;

    /// <summary>
    /// Initialize the collection of invalid characters before we start measuring. Also get the file contents only once.
    /// </summary>
    [GlobalSetup]
    public void InitializeInvalidCharacters()
    {
        var _ = InvalidCharactersToRemove.Value;
        _feedContent = File.ReadAllText("Feeds/AtomSpecialCharacters.xml");
    }

    /*
// * Summary *

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2861/23H2/2023Update/SunValley3)
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 8.0 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=.NET 8.0  Runtime=.NET 8.0

| Method                                 | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|--------------------------------------- |---------:|---------:|---------:|------:|--------:|---------:|----------:|------------:|
| RemoveInvalidCharsAsStringsWithReplace | 24.87 us | 0.492 us | 0.411 us |  1.00 |    0.00 | 107.9712 | 442.23 KB |        1.00 |
| RemoveInvalidCharsInFrozenSet_Span     | 27.33 us | 0.431 us | 0.403 us |  1.10 |    0.02 |   3.4485 |   14.2 KB |        0.03 |

// * Hints *
Outliers
  InvalidCharsSpan.RemoveInvalidCharsAsStringsWithReplace: .NET 8.0 -> 2 outliers were removed (26.65 us, 27.62 us)
  InvalidCharsSpan.RemoveInvalidCharsInFrozenSet_Span: .NET 8.0     -> 1 outlier  was  detected (26.42 us)
     */

    ///// <summary>
    ///// Removes some characters at the beginning of the document. These shouldn't be there, but 
    ///// unfortunately they are sometimes there. If they are not removed, xml parsing would fail.
    ///// </summary>
    ///// <param name="feedContent">RSS feed content.</param>
    ///// <returns>Cleaned up RSS feed content.</returns>
    //[Benchmark(Baseline = true)]
    //public string RemoveInvalidCharsWithReplace()
    //{
    //    var feedContent = _feedContent;//_feedContent.ToString();

    //    // Replaces all control characters except CR LF (\r\n) and TAB.
    //    for (int charCode = 0; charCode <= 31; charCode++)
    //    {
    //        if (charCode == 0x0D || charCode == 0x0A || charCode == 0x09)
    //        {
    //            continue;
    //        }

    //        feedContent = feedContent.Replace(((char)charCode).ToString(), string.Empty);
    //    }

    //    // Replace DEL.
    //    feedContent = feedContent.Replace(((char)127).ToString(), string.Empty);

    //    // Replaces special char, fixes issues with at least one feed.
    //    feedContent = feedContent.Replace(((char)65279).ToString(), string.Empty);

    //    // XDocument chokes with leading white space, so ensure there isn't any.
    //    return feedContent.TrimStart();
    //}

    // This is after and uses less memory. It's the new baseline.
    /// <summary>
    /// Removes some characters at the beginning of the document. These shouldn't be there, but 
    /// unfortunately they are sometimes there. If they are not removed, xml parsing would fail.
    /// </summary>
    /// <param name="feedContent">RSS feed content.</param>
    /// <returns>Cleaned up RSS feed content.</returns>
    [Benchmark(Baseline = true)]
    public string RemoveInvalidCharsAsStringsWithReplace()
    {
        var feedContent = _feedContent;

        foreach (var invalidCharString in _invalidCharStrings)
        {
            feedContent = feedContent.Replace(invalidCharString, string.Empty, StringComparison.Ordinal);
        }

        // XDocument chokes with leading white space, so ensure there isn't any.
        return feedContent.TrimStart();
    }

    [Benchmark]
    public string RemoveInvalidCharsInFrozenSet_Span()
    {
        var feedContent = _feedContent;

        if (feedContent.Length < 128)
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

    private string RemoveInvalidCharsSpanHelper(string content, Span<char> destBuffer)
    {
        var destBufferPos = 0;
        var bytesWritten = 0; // Turns out to be the same as destBufferPos, but use a separate variable for clarity.

        foreach (var ch in content.AsSpan())
        {
            if (InvalidCharactersToRemove.Value.Contains(ch))
            {
                continue;
            }

            destBuffer[destBufferPos++] = ch;
            bytesWritten++;
        }

        return content.Length == bytesWritten
            ? content.TrimStart()
            : destBuffer.Slice(start: 0, length: bytesWritten).TrimStart().ToString();
    }

    // Not as fast as Span-based method.
    //[Benchmark]
    //public string RemoveInvalidCharsInFrozenSet_Memory()
    //{
    //    var feedContent = _feedContent.ToString();

    //    using var memoryOwner = MemoryPool<char>.Shared.Rent(minBufferSize: feedContent.Length);
    //    var bufferMemory = memoryOwner.Memory;

    //    var feedContentSpan = feedContent.AsSpan();
    //    var posDestBuffer = 0;

    //    for (var ixChar = 0; ixChar < feedContentSpan.Length; ixChar++)
    //    {
    //        var ch = feedContentSpan[ixChar];
    //        if (InvalidCharactersToRemove.Value.Contains(ch))
    //        {
    //            continue;
    //        }

    //        bufferMemory.Span[posDestBuffer++] = ch;
    //    }

    //    return feedContent.Length == posDestBuffer
    //        ? feedContent
    //        : bufferMemory.Slice(0, posDestBuffer).ToString().TrimStart();
    //}
}
