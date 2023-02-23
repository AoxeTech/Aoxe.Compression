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
        var result = new MemoryStream(Consts.Data.ToGZip()).UnGZip<MemoryStream>().ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToBytesTest()
    {
        var result = new MemoryStream(Consts.Data).ToGZip<MemoryStream>().ToArray().UnGZip();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public void GZipCompressToStreamAndDecompressToStreamTest()
    {
        var compressStream = new MemoryStream(Consts.Data).ToGZip<MemoryStream>();
        var decompressStream = compressStream.UnGZip<MemoryStream>();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }

    [Fact]
    public async Task GZipCompressToStreamAndDecompressToStreamTestAsync()
    {
        var compressStream = await new MemoryStream(Consts.Data).ToGZipAsync<MemoryStream>();
        var decompressStream = await compressStream.UnGZipAsync<MemoryStream>();
        var result = decompressStream.ToArray();
        Assert.Equal(Consts.Data, result);
    }
}