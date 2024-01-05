using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class SplitStringVsSpan
{
    [Params("category", "itunes:category")]
    public string ElementName { get; set; } = null!;

    private readonly record struct NamespaceAndName(string? Namespace, string Name);

    [Benchmark(Baseline = true)]
    public void StringSplit()
    {
        // Split on the first occurrence of ':'
        var parts = ElementName.Split(":", count: 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var _ = parts.Length == 2
            ? new NamespaceAndName(parts[0], parts[1])
            : new NamespaceAndName(Namespace: null, Name: ElementName);
    }

    [Benchmark]
    public void SpanSplit()
    {
        // Split on the first occurrence of ':'. At most, we should see two elements.
        var elementSpan = ElementName.AsSpan();
        Span<Range> parts = stackalloc Range[2];
        var partsWritten = elementSpan.Split(destination: parts, ':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var _ = partsWritten == 2
            ? new NamespaceAndName(Namespace: elementSpan[parts[0]].ToString(), Name: elementSpan[parts[1]].ToString())
            : new NamespaceAndName(Namespace: null, Name: ElementName);
    }

    /*
    // * Summary *

    BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.2861/23H2/2023Update/SunValley3)
    Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
    .NET SDK 8.0.100
      [Host]   : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
      .NET 8.0 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

    Job=.NET 8.0  Runtime=.NET 8.0

    | Method      | ElementName     | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
    |------------ |---------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
    | StringSplit | category        | 22.09 ns | 0.421 ns | 0.394 ns |  1.00 |    0.00 | 0.0076 |      32 B |        1.00 |
    | SpanSplit   | category        | 20.81 ns | 0.351 ns | 0.328 ns |  0.94 |    0.02 |      - |         - |        0.00 |
    |             |                 |          |          |          |       |         |        |           |             |
    | StringSplit | itunes:category | 65.76 ns | 1.040 ns | 0.973 ns |  1.00 |    0.00 | 0.0286 |     120 B |        1.00 |
    | SpanSplit   | itunes:category | 48.83 ns | 0.721 ns | 0.674 ns |  0.74 |    0.02 | 0.0191 |      80 B |        0.67 |

    // * Hints *
    Outliers
      SplitStringVsSpan.SpanSplit: .NET 8.0 -> 1 outlier  was  detected (21.65 ns)

    // * Legends *
      ElementName : Value of the 'ElementName' parameter
      Mean        : Arithmetic mean of all measurements
      Error       : Half of 99.9% confidence interval
      StdDev      : Standard deviation of all measurements
      Ratio       : Mean of the ratio distribution ([Current]/[Baseline])
      RatioSD     : Standard deviation of the ratio distribution ([Current]/[Baseline])
      Gen0        : GC Generation 0 collects per 1000 operations
      Allocated   : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
      Alloc Ratio : Allocated memory ratio distribution ([Current]/[Baseline])
      1 ns        : 1 Nanosecond (0.000000001 sec)
    */
}
