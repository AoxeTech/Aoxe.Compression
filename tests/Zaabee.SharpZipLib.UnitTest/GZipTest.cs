namespace Zaabee.SharpZipLib.UnitTest;

public class GZipTest
{
    [Fact]
    public void GZipCompressToBytesAndDecompressToBytesTest()
    {
        var result = Consts.Data.ToGZip().UnGZip();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToBytesAndDecompressToStreamTest()
    {
        var result = new MemoryStream(Consts.Data.ToGZip()).UnGZip().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToBytesTest()
    {
        var result = new MemoryStream(Consts.Data).ToGZip().ToArray().UnGZip();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = new MemoryStream(Consts.Data).ToGZip();
        var decompressStream = compressStream.UnGZip();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task GZipCompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await new MemoryStream(Consts.Data).ToGZipAsync();
        var decompressStream = await compressStream.UnGZipAsync();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}