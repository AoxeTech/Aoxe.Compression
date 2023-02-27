namespace Zaabee.SharpZipLib.UnitTest;

public class BZip2Test
{
    [Fact]
    public void BZip2CompressToBytesAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToBZip2().UnBZip2();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToBytesAndDecompressToStreamTest()
    {
        var compressedStream = Consts.Data.ToBZip2().ToMemoryStream();
        var decompressStream = compressedStream.UnBZip2();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToBytesTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var decompressStream = rawStream.ToBZip2();

        Assert.Equal(0, decompressStream.Position);

        var result = decompressStream.ToArray().UnBZip2();

        Assert.Equal(0, rawStream.Position);
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToStreamTest()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = rawStream.ToBZip2();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = compressStream.UnBZip2();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task BZip2CompressToStreamAndDecompressToStreamTestAsync()
    {
        var rawStream = Consts.Data.ToMemoryStream();
        var compressStream = await rawStream.ToBZip2Async();

        Assert.Equal(0, rawStream.Position);

        var decompressStream = await compressStream.UnBZip2Async();

        Assert.Equal(0, compressStream.Position);

        var result = decompressStream.ToArray();

        Assert.Equal(Consts.Data, result);
    }
}