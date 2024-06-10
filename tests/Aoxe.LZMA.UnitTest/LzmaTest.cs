namespace Aoxe.LZMA.UnitTest;

public class LzmaTest
{
    [Fact]
    public void LzmaCompressToBytesAndDecompressToBytesTest()
    {
        var result = TestConsts.Data.ToLzma().UnLzma();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void LzmaCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = TestConsts.Data.ToLzma().ToMemoryStream();
        var decompressStream = compressedStream.UnLzma();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void LzmaCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToLzma();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnLzma();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void LzmaCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = rawStream.ToLzma();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnLzma();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public async Task LzmaCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = TestConsts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToLzmaAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnLzmaAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(TestConsts.Data, result);
    }

    [Fact]
    public void LzmaCompressStringToBytesAndDecompressToStringTestAsync()
    {
        var compressBytes = TestConsts.Str.ToLzma();
        var result = compressBytes.UnLzmaToString();
        Assert.Equal(TestConsts.Str, result);
    }
}
