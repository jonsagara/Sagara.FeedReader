using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

/* Instance is faster; no memory difference.

// * Summary *

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2861/23H2/2023Update/SunValley3)
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 8.0 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=.NET 8.0  Runtime=.NET 8.0

| Method                | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Regex_Static_Match    | 184.18 ns | 3.671 ns | 4.508 ns |  1.00 |    0.00 | 0.0591 |     248 B |        1.00 |
| Regex_Instance_Match  |  99.90 ns | 1.782 ns | 2.721 ns |  0.54 |    0.02 | 0.0592 |     248 B |        1.00 |
| Regex_SourceGen_Match |  97.22 ns | 1.897 ns | 3.272 ns |  0.53 |    0.03 | 0.0592 |     248 B |        1.00 |

*/

[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public partial class RegexStaticVsInstanceVsSourceGen
{
    private const string LinkTag = """
        <link rel="alternate" type="application/rss+xml" title="codehollow > Feed" href="https://codehollow.com/feed/" />
        """;

    [Benchmark(Baseline = true)]
    public void Regex_Static_Match()
    {
        var res = Regex.Match(LinkTag, "href\\s*=\\s*\"(?<val>[^\"]*)\"", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
    }


    private static readonly Regex _rxLinkTagHrefAttribute = new Regex("href\\s*=\\s*\"(?<val>[^\"]*)\"", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

    [Benchmark]
    public void Regex_Instance_Match()
    {
        var res = _rxLinkTagHrefAttribute.Match(LinkTag);
    }


    [GeneratedRegex(pattern: "href\\s*=\\s*\"(?<val>[^\"]*)\"", options: RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace)]
    private static partial Regex LinkTagHrefAttribute();// = new Regex("href" + "\\s*=\\s*\"(?<val>[^\"]*)\"", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

    [Benchmark]
    public void Regex_SourceGen_Match()
    {
        var _ = LinkTagHrefAttribute().Match(LinkTag);
    }
}
