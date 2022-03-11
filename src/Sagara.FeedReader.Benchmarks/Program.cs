using BenchmarkDotNet.Running;
using Sagara.FeedReader.Benchmarks.Harnesses;

//
// Benchmark
//

//BenchmarkRunner.Run<StaticVsInstance>();
BenchmarkRunner.Run<InvalidChars>();


//
// Benchmark: to hit a breakpoint in Debug:
//

//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());

//BenchmarkRunner.Run<StaticVsInstance>(
//    ManualConfig
//        //.Create(DefaultConfig.Instance)
//        .Create(new DebugBuildConfig())
//        .WithOptions(ConfigOptions.DisableOptimizationsValidator)
//    );


//
// For use with dotMemory profiling.
//

//var harness = new StaticVsInstance();
////var harness = new InvalidChars();

//for (var ix = 0; ix < 1_000; ix++)
//{
//    //var feed = await harness.StaticReadFromFileAsync();
//    var feed = await harness.InstanceReadFromFileAsync();

//    //var stuff = harness.RemoveInvalidCharsWithReplace();
//    //var stuff = harness.RemoveInvalidCharsWithSingleCharInspection();
//}
