namespace Sagara.FeedReader.Tests.Unit.Fakes;

/// <summary>
/// A response body that returns some bytes, then never returns more until the read is cancelled, like a server
/// that trickles out its response.
/// </summary>
internal sealed class HangingStream : Stream
{
    private readonly byte[] _initialBytes;
    private bool _initialBytesRead;

    public HangingStream(byte[] initialBytes)
    {
        _initialBytes = initialBytes;
    }

    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;
    public override long Length => throw new NotSupportedException();

    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        if (!_initialBytesRead)
        {
            _initialBytesRead = true;
            _initialBytes.CopyTo(buffer);
            return _initialBytes.Length;
        }

        await Task.Delay(Timeout.Infinite, cancellationToken);
        return 0;
    }

    public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException("Use ReadAsync.");
    public override void Flush() { }
    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
    public override void SetLength(long value) => throw new NotSupportedException();
    public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
}
