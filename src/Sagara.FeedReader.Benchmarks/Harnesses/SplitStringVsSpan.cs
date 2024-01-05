using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Sagara.FeedReader.Benchmarks.Harnesses;

[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class SplitStringVsSpan
{
    private const string NamespacedElement = "itunes:category";

    private readonly record struct NamespaceAndName(string? Namespace, string Name);

    [Benchmark(Baseline = true)]
    public void StringSplit()
    {
        // Split on the first occurrence of ':'
        var parts = NamespacedElement.Split(":", count: 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var _ = parts.Length == 2
            ? new NamespaceAndName(parts[0], parts[1])
            : new NamespaceAndName(Namespace: null, Name: NamespacedElement);
    }

    [Benchmark]
    public void SpanSplit()
    {
        // Split on the first occurrence of ':'. At most, we should see two elements.
        var elementSpan = NamespacedElement.AsSpan();
        Span<Range> parts = stackalloc Range[2];
        var partsWritten = elementSpan.Split(destination: parts, ':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var _ = partsWritten == 2
            ? new NamespaceAndName(Namespace: elementSpan[parts[0]].ToString(), Name: elementSpan[parts[1]].ToString())
            : new NamespaceAndName(Namespace: null, Name: NamespacedElement);
    }

    /*
    // * Summary *

    BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2861/23H2/2023Update/SunValley3)
    Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
    .NET SDK 8.0.100
      [Host]   : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
      .NET 8.0 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

    Job=.NET 8.0  Runtime=.NET 8.0

    | Method      | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
    |------------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
    | StringSplit | 69.36 ns | 1.401 ns | 2.455 ns |  1.00 |    0.00 | 0.0286 |     120 B |        1.00 |
    | SpanSplit   | 50.21 ns | 1.025 ns | 1.848 ns |  0.72 |    0.04 | 0.0191 |      80 B |        0.67 |

    // * Hints *
    Outliers
      SplitStringVsSpan.StringSplit: .NET 8.0 -> 1 outlier  was  detected (64.57 ns)
      SplitStringVsSpan.SpanSplit: .NET 8.0   -> 1 outlier  was  detected (47.39 ns)
    */
}
