namespace Zaabee.LZMA.UnitTest;

public class LzmaTest
{
    [Fact]
    public void LzmaCompressToBytesAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToLzma().UnLzma();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void LzmaCompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = Consts.Data.ToLzma().ToMemoryStream();
        var decompressStream = compressedStream.UnLzma();

        Assert.Equal(0, compressedStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void LzmaCompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToLzma();

        Assert.Equal(0, rawStream.Position);

        var result = decompressStream.ToArray().UnLzma();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void LzmaCompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = rawStream.ToLzma();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnLzma();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task LzmaCompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToLzmaAsync();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnLzmaAsync();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }
}