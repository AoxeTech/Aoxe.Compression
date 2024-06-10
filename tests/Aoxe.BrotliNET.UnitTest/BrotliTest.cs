namespace Aoxe.BrotliNET.UnitTest;

public class BrotliTest
{
    [Fact]
    public void BrotliCompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToBrotli().UnBrotli();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void BrotliCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToBrotli().ToMemoryStream();
        var decompressStream = compressedStream.UnBrotli();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void BrotliCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToBrotli();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnBrotli();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void BrotliCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToBrotli();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnBrotli();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task BrotliCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToBrotliAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnBrotliAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void BrotliCompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToBrotli();
        var result = compressBytes.UnBrotliToString();
        Assert.Equal(TestConsts.Str, result);
    }
}
