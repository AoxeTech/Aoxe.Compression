namespace Aoxe.SharpZipLib.UnitTest;

public class DeflateTest
{
    [Fact]
    public void DeflateCompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToDeflate().UnDeflate();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void DeflateCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToDeflate().ToMemoryStream();
        var decompressStream = compressedStream.UnDeflate();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void DeflateCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToDeflate();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray().UnDeflate();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void DeflateCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToDeflate();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnDeflate();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task DeflateCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToDeflateAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnDeflateAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void DeflateCompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToDeflate();
        var result = compressBytes.UnDeflateToString();
        Assert.Equal(TestConsts.Str, result);
    }
}
