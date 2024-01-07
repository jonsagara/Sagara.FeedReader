using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Sagara.FeedReader.Parser;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class GetEncodingFromXDocumentVsXmlFragment
{
    //const string FilePath = @"Feeds/Rss20MicrosoftBotFramework.xml";
    const string FilePath = @"Feeds/Rss20MicrosoftBotFrameworkUTF16.xml";

    private Stream _xDocumentStream = null!;
    private Stream _xmlFragmentStream = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _xDocumentStream = File.OpenRead(FilePath);
        _xmlFragmentStream = File.OpenRead(FilePath);
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _xDocumentStream.Dispose();
        _xmlFragmentStream.Dispose();
    }


    // 2024-01-06: This method no longer exists.
    //[Benchmark(Baseline = true)]
    //public async Task GetEncodingFromXDocument()
    //{
    //    _xDocumentStream.Position = 0L;
    //    await FeedParser.GetFeedFromStreamAsync_EncodingFromXDocument(_xDocumentStream);
    //}

    // This performs better when the encoding is NOT UTF-8 because it doesn't have to call
    //   XDocument.Parse twice. However, it performs worse in the common case where the encoding
    //   is, or is assumed to be, UTF-8. I haven't been able to figure out why...
    [Benchmark]
    public async Task GetEncodingFromXmlFragment()
    {
        _xmlFragmentStream.Position = 0L;
        await FeedParser.GetFeedFromStreamAsync(_xmlFragmentStream);
    }


    //
    // When the encoding is UTF-8:
    //

    /*
    // * Summary *

    BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2861/23H2/2023Update/SunValley3)
    Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
    .NET SDK 8.0.100
      [Host]   : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
      .NET 8.0 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

    Job=.NET 8.0  Runtime=.NET 8.0

    | Method                     | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
    |--------------------------- |---------:|---------:|---------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
    | GetEncodingFromXDocument   | 726.3 us | 13.78 us | 13.53 us |  1.00 |    0.00 | 85.9375 | 39.0625 | 27.3438 | 390.96 KB |        1.00 |
    | GetEncodingFromXmlFragment | 736.4 us |  8.14 us |  6.80 us |  1.01 |    0.02 | 85.9375 | 35.1563 | 27.3438 | 401.67 KB |        1.03 |

    // * Hints *
    Outliers
      GetEncodingFromXDocumentVsXmlFragment.GetEncodingFromXDocument: .NET 8.0   -> 1 outlier  was  removed (775.53 us)
      GetEncodingFromXDocumentVsXmlFragment.GetEncodingFromXmlFragment: .NET 8.0 -> 2 outliers were removed (766.41 us, 811.51 us)
    */


    //
    // When the encoding is UTF-16:
    //

    /*
    // * Summary *

    BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2861/23H2/2023Update/SunValley3)
    Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
    .NET SDK 8.0.100
      [Host]   : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
      .NET 8.0 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

    Job=.NET 8.0  Runtime=.NET 8.0

    | Method                     | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0     | Gen1    | Gen2    | Allocated | Alloc Ratio |
    |--------------------------- |---------:|----------:|----------:|---------:|------:|--------:|---------:|--------:|--------:|----------:|------------:|
    | GetEncodingFromXDocument   | 1.211 ms | 0.0240 ms | 0.0414 ms | 1.192 ms |  1.00 |    0.00 | 171.8750 | 78.1250 | 54.6875 | 744.97 KB |        1.00 |
    | GetEncodingFromXmlFragment | 1.031 ms | 0.0187 ms | 0.0156 ms | 1.028 ms |  0.85 |    0.04 | 117.1875 | 58.5938 | 58.5938 | 592.55 KB |        0.80 |

    // * Hints *
    Outliers
      GetEncodingFromXDocumentVsXmlFragment.GetEncodingFromXDocument: .NET 8.0   -> 1 outlier  was  removed (1.34 ms)
      GetEncodingFromXDocumentVsXmlFragment.GetEncodingFromXmlFragment: .NET 8.0 -> 2 outliers were removed (1.08 ms, 1.12 ms)
    */
}
