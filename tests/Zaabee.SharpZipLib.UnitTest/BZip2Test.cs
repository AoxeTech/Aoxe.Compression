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
        var result = Consts.Data.ToBZip2().ToMemoryStream().UnBZip2().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToMemoryStream().ToBZip2().ToArray().UnBZip2();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = Consts.Data.ToMemoryStream().ToBZip2();
        var decompressStream = compressStream.UnBZip2();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task BZip2CompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await Consts.Data.ToMemoryStream().ToBZip2Async();
        var decompressStream = await compressStream.UnBZip2Async();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}