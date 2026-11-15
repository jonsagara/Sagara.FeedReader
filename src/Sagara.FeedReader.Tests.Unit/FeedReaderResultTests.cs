using System.Net;
using Xunit;

namespace Sagara.FeedReader.Tests.Unit;

public class FeedReaderResultTests
{
    private static readonly Feed SampleFeed = new() { Title = "Sample" };
    private static readonly FeedReaderError SampleError = new(FeedReaderErrorKind.HttpError, "Not found");


    #region Success

    [Fact]
    public void Success_SetsValueAndClearsError()
    {
        var result = FeedReaderResult.Success(SampleFeed);

        Assert.True(result.IsSuccess);
        Assert.Same(SampleFeed, result.Value);
        Assert.Null(result.Error);
        Assert.Null(result.StatusCode);
        Assert.Null(result.FinalUri);
    }

    [Fact]
    public void Success_WithHttpDetails_SetsStatusCodeAndFinalUri()
    {
        var finalUri = new Uri("https://example.com/feed.xml");

        var result = FeedReaderResult.Success(SampleFeed, HttpStatusCode.OK, finalUri);

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(finalUri, result.FinalUri);
    }

    [Fact]
    public void Success_NullValue_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => FeedReaderResult.Success<Feed>(null!));
    }

    #endregion


    #region Failure

    [Fact]
    public void Failure_SetsErrorAndClearsValue()
    {
        var result = FeedReaderResult.Failure<Feed>(SampleError);

        Assert.False(result.IsSuccess);
        Assert.Same(SampleError, result.Error);
        Assert.Null(result.Value);
        Assert.Null(result.StatusCode);
        Assert.Null(result.FinalUri);
    }

    [Fact]
    public void Failure_WithHttpDetails_SetsStatusCodeAndFinalUri()
    {
        var finalUri = new Uri("https://example.com/moved/feed.xml");

        var result = FeedReaderResult.Failure<Feed>(SampleError, HttpStatusCode.NotFound, finalUri);

        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        Assert.Equal(finalUri, result.FinalUri);
    }

    [Fact]
    public void Failure_NullError_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => FeedReaderResult.Failure<Feed>(null!));
    }

    #endregion


    #region Nullable flow analysis

    // These tests dereference Value and Error without the null-forgiving operator. The unit test project treats
    //   nullable warnings as errors, so if the MemberNotNullWhen attributes on IsSuccess are removed or wrong,
    //   this file stops compiling.

    [Fact]
    public void IsSuccessTrue_ValueIsKnownNotNull()
    {
        FeedReaderResult<Feed> result = FeedReaderResult.Success(SampleFeed);

        if (result.IsSuccess)
        {
            Assert.Equal("Sample", result.Value.Title);
        }
        else
        {
            Assert.Fail(result.Error.Message);
        }
    }

    [Fact]
    public void IsSuccessFalse_ErrorIsKnownNotNull()
    {
        FeedReaderResult<Feed> result = FeedReaderResult.Failure<Feed>(SampleError);

        if (!result.IsSuccess)
        {
            Assert.Equal(FeedReaderErrorKind.HttpError, result.Error.Kind);
        }
        else
        {
            Assert.Fail(result.Value.Title);
        }
    }

    #endregion


    #region FeedReaderError

    [Fact]
    public void FeedReaderError_ExceptionDefaultsToNull()
    {
        var error = new FeedReaderError(FeedReaderErrorKind.Timeout, "Timed out");

        Assert.Null(error.Exception);
    }

    [Fact]
    public void FeedReaderError_HasValueEquality()
    {
        var exception = new InvalidOperationException();

        Assert.Equal(
            new FeedReaderError(FeedReaderErrorKind.NetworkError, "Failed", exception),
            new FeedReaderError(FeedReaderErrorKind.NetworkError, "Failed", exception));
    }

    #endregion
}
