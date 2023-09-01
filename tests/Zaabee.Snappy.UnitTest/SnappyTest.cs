namespace Zaabee.Snappy.UnitTest;

public class SnappyTest
{
    [Fact]
    public void SnappyCompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToSnappy().UnSnappy();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void SnappyCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToSnappy().ToMemoryStream();
        var decompressStream = compressedStream.UnSnappy();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void SnappyCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToSnappy();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnSnappy();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void SnappyCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToSnappy();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnSnappy();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task SnappyCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToSnappyAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnSnappyAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void SnappyCompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToSnappy();
        var result = compressBytes.UnSnappyToString();
        Assert.Equal(TestConsts.Str, result);
    }
}