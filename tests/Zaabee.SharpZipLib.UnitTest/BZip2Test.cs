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
        var result = new MemoryStream(Consts.Data.ToBZip2()).UnBZip2<MemoryStream>().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToBytesTest()
    {
        var result = new MemoryStream(Consts.Data).ToBZip2<MemoryStream>().ToArray().UnBZip2();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void BZip2CompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = new MemoryStream(Consts.Data).ToBZip2<MemoryStream>();
        var decompressStream = compressStream.UnBZip2<MemoryStream>();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task BZip2CompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await new MemoryStream(Consts.Data).ToBZip2Async<MemoryStream>();
        var decompressStream = await compressStream.UnBZip2Async<MemoryStream>();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}