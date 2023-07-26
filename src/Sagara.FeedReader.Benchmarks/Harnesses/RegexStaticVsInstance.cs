using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

/* Instance is faster; no memory difference.

// * Summary *

BenchmarkDotNet v0.13.6, Windows 11 (10.0.22621.1992/22H2/2022Update/SunValley2)
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]   : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0

|               Method |     Mean |   Error |  StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|--------------------- |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
|   Regex_Static_Match | 263.2 ns | 5.16 ns | 5.94 ns |  1.00 |    0.00 | 0.0591 |     248 B |        1.00 |
| Regex_Instance_Match | 111.2 ns | 2.24 ns | 3.06 ns |  0.42 |    0.02 | 0.0591 |     248 B |        1.00 |

*/

[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser]
public class RegexStaticVsInstance
{
    private const string LinkTag = """
        <link rel="alternate" type="application/rss+xml" title="codehollow > Feed" href="https://codehollow.com/feed/" />
        """;

    [Benchmark(Baseline = true)]
    public void Regex_Static_Match()
    {
        var res = Regex.Match(LinkTag, "href" + "\\s*=\\s*\"(?<val>[^\"]*)\"", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
    }


    private static readonly Regex _rxLinkTagHrefAttribute = new Regex("href" + "\\s*=\\s*\"(?<val>[^\"]*)\"", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

    [Benchmark]
    public void Regex_Instance_Match()
    {
        var res = _rxLinkTagHrefAttribute.Match(LinkTag);
    }
}
