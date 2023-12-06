namespace Zaabee.SystemIoCompression.UnitTest;

public class GZipTest
{
    [Fact]
    public void GZipCompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToGZip().UnGZip();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void GZipCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToGZip().ToMemoryStream();
        var decompressStream = compressedStream.UnGZip();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToGZip();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray().UnGZip();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToGZip();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnGZip();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task GZipCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToGZipAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnGZipAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void GZipCompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToGZip();
        var result = compressBytes.UnGZipToString();
        Assert.Equal(TestConsts.Str, result);
    }
}
