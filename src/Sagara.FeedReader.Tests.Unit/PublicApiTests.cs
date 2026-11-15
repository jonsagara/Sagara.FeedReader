using System.Runtime.CompilerServices;
using PublicApiGenerator;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

/// <summary>
/// Fails when the library's public API changes, so that every change to it is deliberate and shows up in code review.
/// </summary>
/// <remarks>
/// <para>If the change is intended: copy PublicApi.received.txt over PublicApi.approved.txt (both are next to this file),
/// and commit the approved file.</para>
/// <para>If it isn't: make the new type or member internal or private.</para>
/// </remarks>
public class PublicApiTests
{
    private const string ApprovedFileName = "PublicApi.approved.txt";
    private const string ReceivedFileName = "PublicApi.received.txt";

    [Fact]
    public void PublicApi_HasNotChanged()
    {
        var publicApi = typeof(FeedReader).Assembly.GeneratePublicApi(new ApiGeneratorOptions
        {
            // By default, types in System.* and Microsoft.* namespaces are skipped. AddFeedReaderServices lives in
            //   Microsoft.Extensions.DependencyInjection, and it's part of our API.
            AllowNamespacePrefixes = ["Microsoft.Extensions.DependencyInjection"],

            // These differ between target frameworks and builds, and aren't part of the API.
            ExcludeAttributes =
            [
                "System.Runtime.Versioning.TargetFrameworkAttribute",
                "System.Reflection.AssemblyMetadataAttribute",
                "System.Runtime.CompilerServices.InternalsVisibleToAttribute",
            ],
        });
        publicApi = NormalizeLineEndings(publicApi);

        var testDirectory = GetThisFilesDirectory();
        var approvedPath = Path.Combine(testDirectory, ApprovedFileName);
        var receivedPath = Path.Combine(testDirectory, ReceivedFileName);

        var approved = File.Exists(approvedPath)
            ? NormalizeLineEndings(File.ReadAllText(approvedPath))
            : string.Empty;

        if (publicApi == approved)
        {
            File.Delete(receivedPath);
            return;
        }

        File.WriteAllText(receivedPath, publicApi);

        Assert.Fail($"""
            The public API has changed. Compare {ReceivedFileName} with {ApprovedFileName} in {testDirectory}.
            If the change is intended, copy {ReceivedFileName} over {ApprovedFileName} and commit it.
            """);
    }

    private static string NormalizeLineEndings(string text)
        => text.Replace("\r\n", "\n", StringComparison.Ordinal);

    private static string GetThisFilesDirectory([CallerFilePath] string callerFilePath = "")
        => Path.GetDirectoryName(callerFilePath)!;
}
