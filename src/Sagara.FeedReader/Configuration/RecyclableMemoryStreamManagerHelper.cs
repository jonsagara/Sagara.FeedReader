using Microsoft.IO;

namespace Sagara.FeedReader.Configuration;

internal static class RecyclableMemoryStreamManagerHelper
{
    internal static RecyclableMemoryStreamManager.Options GetDefaultRecyclableMemoryStreamManagerOptions()
    {
        // 128 KB
        const int blockSizeBytes = 128 * 1024;
        // 1 MB
        const int largeBufferMultipleBytes = 1024 * 1024;
        // 128 MB
        const int maximumBufferSizeBytes = 128 * 1024 * 1024;
        // 12.5 MB
        const int maximumSmallPoolFreeBytes = 100 * blockSizeBytes;
        // 512 MB
        const int maximumLargePoolFreeBytes = maximumBufferSizeBytes * 4;

        return new RecyclableMemoryStreamManager.Options
        {
            BlockSize = blockSizeBytes,
            LargeBufferMultiple = largeBufferMultipleBytes,
            MaximumBufferSize = maximumBufferSizeBytes,
            MaximumSmallPoolFreeBytes = maximumSmallPoolFreeBytes,
            MaximumLargePoolFreeBytes = maximumLargePoolFreeBytes,
        };
    }
}
