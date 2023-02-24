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
        var result = new MemoryStream(Consts.Data.ToBZip2()).UnBZip2().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToBytesTest()
    {
        var result = new MemoryStream(Consts.Data).ToBZip2().ToArray().UnBZip2();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = new MemoryStream(Consts.Data).ToBZip2();
        var decompressStream = compressStream.UnBZip2();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task BZip2CompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await new MemoryStream(Consts.Data).ToBZip2Async();
        var decompressStream = await compressStream.UnBZip2Async();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}