namespace Aoxe.SharpZipLib.UnitTest;

public class BZip2Test
{
    [Fact]
    public void BZip2CompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToBZip2().UnBZip2();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void BZip2CompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToBZip2().ToMemoryStream();
        var decompressStream = compressedStream.UnBZip2();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToBZip2();

        var result = decompressStream.ToArray().UnBZip2();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToBZip2();

        Assert.Equal(0, rawStream.Position);

        compressStream.TrySeek(0, SeekOrigin.Begin);
        var decompressStream = compressStream.UnBZip2();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task BZip2CompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToBZip2Async();

        Assert.Equal(0, rawStream.Position);

        compressStream.TrySeek(0, SeekOrigin.Begin);
        var decompressStream = await compressStream.UnBZip2Async();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void BZip2CompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToBZip2();
        var result = compressBytes.UnBZip2ToString();
        Assert.Equal(TestConsts.Str, result);
    }
}
